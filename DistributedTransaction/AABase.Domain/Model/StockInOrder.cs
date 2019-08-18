using System;
using System.Collections.Generic;
using System.Text;
namespace AABase.Domain.Model
{
   public class StockInOrder
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
        /// 入库类型
        /// </summary>
        public int StockInType
        {
            get;
            set;
        }
             
       
        /// <summary>
        /// 单据编号
        /// </summary>
        public string BillNum
        {
            get;
            set;
        }
             
       
        /// <summary>
        /// 关联单据id
        /// </summary>
        public Guid ObjectOrderId
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
             
          
     }
}


