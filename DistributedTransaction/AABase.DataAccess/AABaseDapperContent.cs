using AA.Dapper;
using AABase.Common.Util;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace AABase.DataAccess
{
    public class AABaseDapperContent : DapperContext
    {
        public AABaseDapperContent() : base(new NameValueCollection()
        {
            ["aa.dataSource.AaBase.connectionString"] = ConfigUtil.GetSectionValue("ConnectionString"),
            ["aa.dataSource.AaBase.provider"] = "SqlServer"
        })
        {
        }
    }
}
