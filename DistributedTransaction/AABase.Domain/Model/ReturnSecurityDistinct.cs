using System;
using System.Collections.Generic;
using System.Text;
namespace AABase.Domain.Model
{
    /// <summary>
    /// 退货防伪码初始化去重
    /// </summary>
   public class ReturnSecurityDistinct
    {
       
        /// <summary>
        /// 
        /// </summary>
        public Guid MsgId
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
             
          
     }
}


