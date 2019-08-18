using AA.Dapper.Repositories;
using AA.FrameWork.Domain;
using AABase.Domain.Model;
using AABase.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AABase.Domain.Repository
{
   public interface IReturnOrderRepository: IDapperRepository<ReturnOrder>
    {
        IPage<ReturnOrderDto> GetListReturnOrder(GetListReturnOrderInput input);
    }
}
