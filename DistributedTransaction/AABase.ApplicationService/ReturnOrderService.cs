using AA.Dapper;
using AA.Dapper.Repositories;
using AA.FrameWork.Application.Services.Dto;
using AA.FrameWork.Domain;
using AA.ServiceBus;
using AABase.Common.Util;
using AABase.DataAccess;
using AABase.DataAccess.Repository;
using AABase.Domain.Model;
using AABase.Domain.Repository;
using AABase.Dto;
using AABase.EntityEnum;
using AABase.ServiceBus.MsgContracts;
using MassTransit;
using MassTransit.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AABase.ApplicationService
{
    public class ReturnOrderService : IReturnOrderService
    {
        #region filed
        private readonly IReturnOrderRepository _returnOrderRepository;
        private readonly IReturnEventMsgRepository _returnEventMsgRepository ;
        #endregion 

        #region actor
        public ReturnOrderService()
        {
            var dapperContent = new AABaseDapperContent();
            _returnOrderRepository = new ReturnOrderRepository();
            _returnEventMsgRepository = new ReturnEventMsgRepository();
        }

        #endregion
        /// <summary>
        /// 模拟新增退货单
        /// </summary>
        /// <param name="input"></param>
        public void Save(SaveReturnOrderInput input)
        {
            _returnOrderRepository.Insert(new ReturnOrder
            {
                Id = Guid.NewGuid(),
                BillNum = input.BillNum,
                GmtCreate = input.GmtCreate,
                Status = input.Status,
                GmtModified = input.GmtModified,
            });
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="input"></param>
        public void Update(UpdateReturnOrderInput input)
        {
            //更改退货单状态
            var model = _returnOrderRepository.Get(input.Id);
            Guid msgId = Guid.NewGuid();
            using (var transaction = DapperContext.Current.BeginTransaction())
            {
                try
                {
                    //修改退货表审核状态.....省了掉好多业务细节，只为演示
                    model.Id = input.Id;
                    model.Status =(int)ReturnOrderStatus.审核通过;
                    model.GmtModified = input.GmtModified;
                    _returnOrderRepository.Update(model);
                    //插入退货事件消息表
                    _returnEventMsgRepository.Insert(new ReturnEventMsg()
                    {
                        Id = Guid.NewGuid(),
                        MsgId=msgId,
                        ConsumerSatus= (int)ConsumerSatus.待消费,
                        EventMsgType= (int)ReturnEventMsgType.退货防伪初始化,
                        ReturnOrderId=input.Id,
                        GmtCreate=DateTime.Now,
                        GmtModified=DateTime.Now,
                        RetryCount=0
                    });
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
            //发布消息到总线
            #region 
            var rabbitMqUri = ConfigUtil.GetSectionValue("EventBusConnection");
            var rabbitMqUserName = ConfigUtil.GetSectionValue("EventBusUserName");
            var rabbitMqPassword = ConfigUtil.GetSectionValue("EventBusPassword");
            #endregion
            IBusControl busControl = ServiceBusManager.Instance.UseRabbitMq(rabbitMqUri, rabbitMqUserName, rabbitMqPassword)
                .BuildEventProducer();
            //发布退货单已审核事件
            TaskUtil.Await(busControl.Publish<ReturnOrderAudited>(new
            {
                ReturnOrderId = input.Id,
                MsgId= msgId
            }));

        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagedResultDto<ReturnOrderDto> GetList(GetListReturnOrderInput input)
        {
            var result = _returnOrderRepository.GetListReturnOrder(input);
            var items = result.Data.ToList();
            return new PagedResultDto<ReturnOrderDto>()
            {
                TotalCount = result.Count,
                Items = items
            };
        }
    }
}
