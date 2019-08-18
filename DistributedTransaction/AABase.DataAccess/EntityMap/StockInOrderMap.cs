using AA.Dapper.FluentMap.Dommel.Mapping;
using AABase.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AABase.DataAccess.EntityMap
{
   public class StockInOrderMap:DommelEntityMap<StockInOrder>
    {
        public StockInOrderMap()
        {
            ToTable("AA_StockInOrder");
            Map(x=>x.Id).IsKey();
        }
    }
}

