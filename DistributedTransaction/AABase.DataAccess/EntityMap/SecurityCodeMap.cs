using AA.Dapper.FluentMap.Dommel.Mapping;
using AABase.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AABase.DataAccess.EntityMap
{
   public class SecurityCodeMap:DommelEntityMap<SecurityCode>
    {
        public SecurityCodeMap()
        {
            ToTable("AA_SecurityCode");
            Map(x=>x.Id).IsKey();
        }
    }
}

