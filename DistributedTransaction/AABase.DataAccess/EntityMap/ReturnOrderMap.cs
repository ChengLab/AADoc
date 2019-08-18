﻿using AA.Dapper.FluentMap.Dommel.Mapping;
using AABase.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AABase.DataAccess.EntityMap
{
   public class ReturnOrderMap:DommelEntityMap<ReturnOrder>
    {
        public ReturnOrderMap()
        {
            ToTable("AA_ReturnOrder");
            Map(x=>x.Id).IsKey();
        }
    }
}

