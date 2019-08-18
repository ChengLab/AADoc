using AA.Dapper;
using AA.Dapper.Repositories;
using AA.FrameWork.Domain;
using AABase.Domain.Model;
using AABase.Domain.Repository;
using AABase.Dto;
using System;
using System.Collections.Generic;
using System.Text;


namespace AABase.DataAccess.Repository
{
    public class ReturnOrderRepository : DapperRepository<ReturnOrder>, IReturnOrderRepository
    {
        public IPage<ReturnOrderDto> GetListReturnOrder(GetListReturnOrderInput input)
        {
            object sqlParam = null;
            var sql = new StringBuilder();
            sql.Append("select *  from AA_ReturnOrder ");
            sql.Append(" where 1=1");
            var result = DapperContext.Current.DataBase.GetPage<ReturnOrderDto>(new PageRequest
            {
                PageIndex = input.PageIndex,
                PageSize = input.PageSize,
                SqlText = sql.ToString(),
                SqlParam = sqlParam,
                OrderFiled = " Id desc ",
            });
            return result;
        }
    }
}

