using AA.FrameWork.Logging;
using AABase.DataAccess;
using AABase.DataAccess.Repository;
using AABase.Domain.Repository;
using AABase.EntityEnum;
using AABase.ServiceBus.MsgContracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AABase.Consumers
{
    public class SecurityServiceConsumer : IConsumer<ReturnOrderAudited>
    {
        #region filed
        private readonly IReturnSecurityDistinctRepository _returnSecurityDistinctRepository;
        private readonly ISecurityCodeRepository _securityCodeRepository;
        private readonly IReturnEventMsgRepository _returnEventMsgRepository;
        #endregion
        ILog log = Logger.Get(typeof(SecurityServiceConsumer));
        public SecurityServiceConsumer()
        {
            var dapperContent = new AABaseDapperContent();
            _returnSecurityDistinctRepository = new ReturnSecurityDistinctRepository();
            _securityCodeRepository = new SecurityCodeRepository();
            _returnEventMsgRepository = new ReturnEventMsgRepository();
        }
        /// <summary>
        /// 消费
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Consume(ConsumeContext<ReturnOrderAudited> context)
        {
            var @event = context.Message;
            log.Debug($"接收到退货单编号:{@event.ReturnOrderId} ");
            //do somethings..
            //消费端 需要具有幂等性
            var isConsumed = _returnSecurityDistinctRepository.Get(@event.MsgId)!=null;
            var bizResult = true;
            if (!isConsumed)
            {
                var codeModel = _securityCodeRepository.Get("edb13d0b-004f-43e3-ab7f-e5e5e4a01665");
                using (var transaction = AA.Dapper.DapperContext.Current.BeginTransaction())
                {
                    try
                    {
                        //处理业务。。
                        codeModel.EnabledState = 0;//初始化0
                        _securityCodeRepository.Update(codeModel);
                        //插入去重表
                        _returnSecurityDistinctRepository.Insert(new Domain.Model.ReturnSecurityDistinct
                        {
                            MsgId = @event.ReturnOrderId,
                            GmtCreate = DateTime.Now
                        });
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        bizResult = false;
                        transaction.Rollback();
                        log.Error(ex.Message);
                    }
                }
            }
            //通知事件消息表  更改消费状态为 消费成功
            if (bizResult)
            {
                var msgModel = _returnEventMsgRepository.FirstOrDefault(p => p.MsgId == @event.MsgId);
                msgModel.ConsumerSatus = (int)ConsumerSatus.已消费;
                await _returnEventMsgRepository.UpdateAsync(msgModel);
            }
           
        }
    }
}
