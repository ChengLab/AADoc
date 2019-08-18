using System;
using System.Collections.Generic;
using System.Text;
namespace AABase.Domain.Model
{
   public class ReturnEventMsg
    {
       
        /// <summary>
        /// 
        /// </summary>
        public Guid Id
        {
            get;
            set;
        }
             
       
        /// <summary>
        /// 
        /// </summary>
        public Guid MsgId
        {
            get;
            set;
        }
             
       
        /// <summary>
        /// 10 待消费20 消费成功 
       /// </summary>
        public int ConsumerSatus
        {
            get;
            set;
        }
             
       
        /// <summary>
        /// 
        /// </summary>
        public Guid ReturnOrderId
        {
            get;
            set;
        }
             
       
        /// <summary>
        /// 10 -防伪码初始化； 20 入库单创建
        /// </summary>
        public int EventMsgType
        {
            get;
            set;
        }
             
       
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime GmtCreate
        {
            get;
            set;
        }
       
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime GmtModified
        {
            get;
            set;
        }
        /// <summary>
        /// 重试次数
        /// </summary>
        public int RetryCount { get; set; }
     }
}


