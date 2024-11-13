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
    public class LaborDAO : ILabor
    {
        private readonly IDbConnection _dbconnection;

        public LaborDAO(IDbConnection dbconnection)
        {
            _dbconnection = dbconnection;
        }
        public async Task<bool> AddAsync(Labor labor)
        {
            var sql = "INSERT INTO Labors ( Service_id, Description, Mechanic_id, HoursWorked ) " +
                    "VALUES (@Service_id, @Description, @Mechanic_id, @HoursWorked)";
            var result = await _dbconnection.ExecuteAsync(sql, labor);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Labors WHERE Id = @Id";
            var result = await _dbconnection.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }

        public async Task<IEnumerable<Labor>> GetAllLaborsAsync()
        {
            var sql = @"SELECT * FROM Labors";

            return await _dbconnection.QueryAsync<Labor>(sql, new { });
        }

        public async Task<IEnumerable<Labor>> GetAllLaborsByMechaniceAsync(int mechanicId)
        {
            var sql = @"SELECT * FROM Labors WHERE Mechanic_id = @Mechanic_id";

            return await _dbconnection.QueryAsync<Labor>(sql, new { Mechanic_id = mechanicId });
        }

        public async Task<IEnumerable<Labor>> GetAllLaborsByServiceAsync(int serviceId)
        {

            var sql = @"SELECT * FROM Labors WHERE Service_id = @Service_id";

            return await _dbconnection.QueryAsync<Labor>(sql, new { Service_id = serviceId });
        }

        public async Task<Labor> GetByIdAsync(int id)
        {
            var sql = @"SELECT * FROM Labors WHERE  Id = @Id";

            return await _dbconnection.QuerySingleOrDefaultAsync<Labor>(sql, new { Id = id });
        }

        public async Task<bool> UpdateAsync(Labor labor)
        {
            var sql = "UPDATE Labors SET Service_id = @Service_id, Description = @Description, Mechanic_id = @Mechanic_id, " +
                    "HoursWorked = @HoursWorked " +
                    "WHERE Id = @Id";
            var result = await _dbconnection.ExecuteAsync(sql, labor);
            return result > 0;
        }
    }
}
