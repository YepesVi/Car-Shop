using Dapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ServiceDAO : IService
    {

        private readonly IDbConnection _dbconnection;

        public ServiceDAO(IDbConnection dbconnection)
        {
            _dbconnection = dbconnection;
        }

        public async Task<bool> AddServiceAsync(Service service)
        {
            var sql = "INSERT INTO Services ( Car_id, EntranceDate, FinishedDate, TotalPrice ) " +
                       "VALUES (@Car_id, @EntranceDate, @FinishedDate, @TotalPrice)";
            var result = await _dbconnection.ExecuteAsync(sql, service);
            return result > 0;
        }

        public async Task<bool> DeleteServiceAsync(int Id)
        {
            var sql = "DELETE FROM Services WHERE Id = @Id";
            var result = await _dbconnection.ExecuteAsync(sql, new { Id = Id });
            return result > 0;
        }

        public async Task<Service> GetActiveServiceAsync(int Car_id)
        {
            var sql = @"SELECT * FROM Services WHERE  Car_id = @Car_id AND FinishedDate IS NULL";

            return await _dbconnection.QuerySingleOrDefaultAsync<Service>(sql, new { Car_id = Car_id });
        }

        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            var sql = @"SELECT * FROM Services";

            return await _dbconnection.QueryAsync<Service>(sql, new { });
        }

        public async Task<IEnumerable<Service>> GetServiceByCarIDAsync(int Car_d)
        {
            var sql = @"SELECT * FROM Services WHERE  Car_id = @Car_id";

            return await _dbconnection.QueryAsync<Service>(sql, new { Car_id = Car_d });
        }
        public async Task<IEnumerable<Service>> GetServiceListByIDAsync(int Id)
        {
            var sql = @"SELECT * FROM Services WHERE  Id = @Id";

            return await _dbconnection.QueryAsync<Service>(sql, new { Id = Id });
        }


        public async Task<IEnumerable<Service>> GetServicesByCarCategoryAsync(int categoryId)
        {
            string sql = @"
                SELECT s.*
                FROM Services s
                JOIN Cars c ON s.Car_id = c.Id
                WHERE c.CarCategory_id = @CategoryId AND s.FinishedDate IS NULL"
            ;

            var services = await _dbconnection.QueryAsync<Service>(sql, new { CategoryId = categoryId });
            return services;
        }

        public async Task<Service> GetServicesByIdAsync(int Id)
        {
            var sql = @"SELECT * FROM Services WHERE  Id = @Id";

            return await _dbconnection.QuerySingleOrDefaultAsync<Service>(sql, new { Id = Id });
        }

        public async Task<bool> UpdateServiceAsync(Service service)
        {
            var sql = "UPDATE Services SET Car_id = @Car_id, EntranceDate = @EntranceDate, FinishedDate = @FinishedDate, " +
                     "TotalPrice = @TotalPrice " +
                     "WHERE Id = @Id";
            var result = await _dbconnection.ExecuteAsync(sql, service);
            return result > 0;
        }
    }
}
