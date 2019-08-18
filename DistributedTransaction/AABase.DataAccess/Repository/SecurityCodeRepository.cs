using AA.Dapper;
using AA.Dapper.Repositories;
using AABase.Domain.Model;
using AABase.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;


namespace AABase.DataAccess.Repository
{
    public class SecurityCodeRepository:DapperRepository<SecurityCode>, ISecurityCodeRepository
    {}
}

