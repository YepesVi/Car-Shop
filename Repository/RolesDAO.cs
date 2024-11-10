using Dapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RolesDAO : IRoles
    {
        private readonly IDbConnection _dbconnection;

        public RolesDAO(IDbConnection dbconnection)
        {
            _dbconnection = dbconnection;
        }
        public async Task<IEnumerable<Roles>> GetAllRolesAsync()
        {
            var sql = @"SELECT * FROM Role";

            return await _dbconnection.QueryAsync<Roles>(sql, new { });
        }
    }
}
