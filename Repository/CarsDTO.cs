using Dapper;
using Entity;
using System.Data;

namespace Repository
{
    public class CarsDTO : ICars
    {
        private readonly IDbConnection _dbconnection;

        public CarsDTO(IDbConnection dbconnection)
        {
            _dbconnection = dbconnection;
        }

        async Task<IEnumerable<Car>> ICars.GetAllCars()
        {
            var sql = @"SELECT * FROM Cars";

            return await _dbconnection.QueryAsync<Car>(sql, new { });

        }
    }
}
