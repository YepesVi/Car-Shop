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
    public class PartDAO : IPart
    {

        private readonly IDbConnection _dbconnection;

        public PartDAO(IDbConnection dbconnection)
        {
            _dbconnection = dbconnection;
        }

        public async Task<bool> AddAsync(Part part)
        {
            var sql = "INSERT INTO Parts ( Service_id, Name, Price, Quantity ) " +
                       "VALUES (@Service_id, @Name, @Price, @Quantity)";
            var result = await _dbconnection.ExecuteAsync(sql, part);
            return result > 0;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var sql = "DELETE FROM Parts WHERE Id = @Id";
            var result = await _dbconnection.ExecuteAsync(sql, new { Id = Id });
            return result > 0;
        }
            
        public async Task<IEnumerable<Part>> GetAllPartsAsync()
        {

            var sql = @"SELECT * FROM Parts";

            return await _dbconnection.QueryAsync<Part>(sql, new { });
        }

        public async Task<IEnumerable<Part>> GetAllPartsByServiceAsync(int serviceId)
        {
            var sql = @"SELECT * FROM Parts WHERE Service_id = @Service_id";

            return await _dbconnection.QueryAsync<Part>(sql, new { Service_id =  serviceId });
        }

        public async Task<Part> GetByIdAsync(int id)
        {
            var sql = @"SELECT * FROM Parts WHERE  Id = @Id";

            return await _dbconnection.QuerySingleOrDefaultAsync<Part>(sql, new { Id = id });
        }

        public async Task<bool> UpdateAsync(Part part)
        {
            var sql = "UPDATE Parts SET Service_id = @Service_id, Name = @Name, Price = @Price, " +
                    "Quantity = @Quantity " +
                    "WHERE Id = @Id";
            var result = await _dbconnection.ExecuteAsync(sql, part);
            return result > 0;
        }
    }
}
