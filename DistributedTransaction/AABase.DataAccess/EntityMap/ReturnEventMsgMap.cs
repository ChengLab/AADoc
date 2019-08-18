using AA.Dapper.FluentMap.Dommel.Mapping;
using AABase.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AABase.DataAccess.EntityMap
{
   public class ReturnEventMsgMap:DommelEntityMap<ReturnEventMsg>
    {
        public ReturnEventMsgMap()
        {
            ToTable("AA_ReturnEventMsg");
            Map(x=>x.Id).IsKey();
        }
    }
}

