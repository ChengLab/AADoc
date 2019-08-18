using AA.Dapper;
using AA.FrameWork.Logging;
using AA.ServiceBus;
using AABase.Common.Util;
using AABase.Dto;
using AABase.ServiceBus.MsgContracts;
using MassTransit;
using MassTransit.Util;
using Quartz;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Base.Timing.AAJob
{
    /// <summary>
    /// 重试服务job demo
    /// </summary>
    public class RetryServiceJob : IJob
    {
        private readonly static ILog log = Logger.Get(typeof(RetryServiceJob));
        public Task Execute(IJobExecutionContext context)
        {
            var dapperContext = new DapperContext(new NameValueCollection()
            {
                ["aa.dataSource.AaBase.connectionString"] = ConfigUtil.GetSectionValue("ConnectionString"),
                ["aa.dataSource.AaBase.provider"] = "SqlServer"
            });

            //重试策略 根据实际需要自己去定义  10分钟重试第一次，20分钟后在重试第二次，1个小时后在重试第三次； 人工介入。
            int[] Diff = { 0, 10, 20, 1 };
            #region sql
            StringBuilder sbSql = new StringBuilder(" SELECT *,CASE RetryCount  ");
            sbSql.Append("  WHEN 1 THEN DATEDIFF (minute  , GmtCreate , GETDATE() )    ");
            sbSql.Append("  WHEN 2	 THEN DATEDIFF (minute  , GmtCreate , GETDATE() )    ");
            sbSql.Append(" WHEN 3	 THEN DATEDIFF (hour , GmtCreate , GETDATE() )  ELSE 0   ");
            sbSql.Append("         END AS Diff  FROM AA_ReturnEventMsg WHERE ConsumerSatus=10 and RetryCount<4   ");
            #endregion
            var msgList = dapperContext.DataBase.Query<ReturnEventMsgDto>(sbSql.ToString());
            log.Debug($"重试数据数量：{msgList.Count()}");

            //需要重试的
            var retryMsg = msgList.Where(_=>_.Diff >= Diff[_.RetryCount]);

            if (retryMsg.Any())
            {
                RetryPublishMsg(retryMsg);
            }
            retryMsg.ToList().ForEach(_=> {
                var sql = "UPDATE AA_ReturnEventMsg set RetryCount=RetryCount+1 ,GmtModified=@GmtModified where Id=@Id ";
                dapperContext.DataBase.Execute(sql, new
                {
                    Id = _.Id,
                    GmtModified = DateTime.Now
                });
            });
            
            return Task.FromResult(true);
        }

        public void RetryPublishMsg(IEnumerable<ReturnEventMsgDto> msgData)
        {
            //发布消息到总线
            var rabbitMqUri = ConfigUtil.GetSectionValue("EventBusConnection");
            var rabbitMqUserName = ConfigUtil.GetSectionValue("EventBusUserName");
            var rabbitMqPassword = ConfigUtil.GetSectionValue("EventBusPassword");
            IBusControl busControl = ServiceBusManager.Instance.UseRabbitMq(rabbitMqUri, rabbitMqUserName, rabbitMqPassword)
                .BuildEventProducer();
            //发布退货单已审核事件
            msgData.ToList().ForEach(_=> {
                TaskUtil.Await(busControl.Publish<ReturnOrderAudited>(new
                {
                    ReturnOrderId = _.ReturnOrderId,
                    MsgId = _.MsgId
                }));
            });
        }
         

    }
}
