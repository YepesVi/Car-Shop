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
    public class SpecializationsDAO : ISpecializations
    {
        private readonly IDbConnection _dbconnection;

        public SpecializationsDAO(IDbConnection dbconnection)
        {
            _dbconnection = dbconnection;
        }
        public async Task<IEnumerable<Specializations>> GetAllSpecializationsAsync()
        {
            var sql = @"SELECT * FROM Specializations";

            return await _dbconnection.QueryAsync<Specializations>(sql, new { });
        }
    }
}
