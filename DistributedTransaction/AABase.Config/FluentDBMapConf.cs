using System;
using System.Collections.Generic;
using System.Text;
using AA.Dapper.Configuration;
using AA.Dapper.FluentMap.Configuration;
using AABase.DataAccess.EntityMap;
namespace AABase.InitConfig
{
   public static class FluentDBMapConf
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Map()
        {
            Action<FluentMapConfiguration> mps = x =>
            {
                x.AddMap(new ReturnOrderMap());
                x.AddMap(new SecurityCodeMap());
                x.AddMap(new StockInOrderMap());
                x.AddMap(new ReturnEventMsgMap());
                x.AddMap(new ReturnSecurityDistinctMap());
            };
            var fluentMapconfig = new List<Action<FluentMapConfiguration>>();
            fluentMapconfig.Add(mps);
            MapConfiguration.Init(fluentMapconfig);
        }
    }
}


