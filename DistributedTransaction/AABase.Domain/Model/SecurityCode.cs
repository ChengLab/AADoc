using System;
using System.Collections.Generic;
using System.Text;
namespace AABase.Domain.Model
{
   public class SecurityCode
    {
       
        /// <summary>
        /// id
        /// </summary>
        public Guid Id
        {
            get;
            set;
        }
             
       
        /// <summary>
        /// 防伪码
        /// </summary>
        public string Code
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
        /// 启用状态
        /// </summary>
        public int EnabledState
        {
            get;
            set;
        }
             
          
     }
}


