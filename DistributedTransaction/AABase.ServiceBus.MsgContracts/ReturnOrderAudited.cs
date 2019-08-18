using System;
using System.Collections.Generic;
using System.Text;

namespace AABase.ServiceBus.MsgContracts
{
    /// <summary>
    /// 退货单已审核消息契约
    /// </summary>
    public interface ReturnOrderAudited
    {
        /// <summary>
        /// 退货单编号
        /// </summary>
        Guid ReturnOrderId { get; set; }
        /// <summary>
        /// 消息编号
        /// </summary>
        Guid MsgId { get; set; }
    }
}
