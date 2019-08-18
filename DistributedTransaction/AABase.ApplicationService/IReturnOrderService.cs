using AA.FrameWork.Application.Services.Dto;
using AABase.Dto;
using System;
using System.Collections.Generic;
using System.Text;
namespace AABase.ApplicationService
{
    public interface IReturnOrderService
    {    
         void Save(SaveReturnOrderInput input);
         void Update(UpdateReturnOrderInput input);
         PagedResultDto<ReturnOrderDto> GetList(GetListReturnOrderInput input);
    }
}


