using System;
using System.Collections.Generic;
using System.Text;
namespace AABase.Dto
{
   public class SaveReturnOrderInput
    {
		/// <summary>
		/// 单据编号	  
		/// </summary>
        public string BillNum { get; set; }
		/// <summary>
		/// 创建时间	  
		/// </summary>
        public DateTime GmtCreate { get; set; }
		/// <summary>
		/// 状态	  
		/// </summary>
        public int Status { get; set; }
		/// <summary>
		/// 修改时间	  
		/// </summary>
        public DateTime GmtModified { get; set; }
    }
}


