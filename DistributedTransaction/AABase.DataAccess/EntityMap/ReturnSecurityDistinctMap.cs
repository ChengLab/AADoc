using AA.Dapper.FluentMap.Dommel.Mapping;
using AABase.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AABase.DataAccess.EntityMap
{
   public class ReturnSecurityDistinctMap:DommelEntityMap<ReturnSecurityDistinct>
    {
        public ReturnSecurityDistinctMap()
        {
            ToTable("AA_ReturnSecurityDistinct");
            Map(x=>x.MsgId).IsKey();
        }
    }
}

