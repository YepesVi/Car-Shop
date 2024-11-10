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
    public class CarCategoryDAO : ICarCategory
    {
        private readonly IDbConnection _dbconnection;

        public CarCategoryDAO(IDbConnection dbconnection)
        {
            _dbconnection = dbconnection;
        }
        public async Task<IEnumerable<CarCategory>> GetAllCategoriesAsync()
        {
            var sql = @"SELECT * FROM CarCategories";

            return await _dbconnection.QueryAsync<CarCategory>(sql, new { });
        }
    }
}
