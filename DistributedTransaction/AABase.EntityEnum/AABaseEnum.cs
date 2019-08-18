using System;
using System.Collections.Generic;
using System.Text;

namespace AABase.EntityEnum
{
    /// <summary>
    /// 退货单状态
    /// </summary>
    public enum ReturnOrderStatus
    {
        待审核 = 10,
        审核通过 = 20,
    }
    /// <summary>
    /// 消费状态
    /// </summary>
    public enum ConsumerSatus
    {
        待消费 = 10,
        已消费 = 20,
    }
    /// <summary>
    /// 退货事件消息类型
    /// </summary>
    public enum ReturnEventMsgType
    {
        退货防伪初始化 = 1,
        退货入库 = 20,
    }
}
