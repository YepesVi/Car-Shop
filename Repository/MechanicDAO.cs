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
    public class MechanicDAO : IMechanic
    {
        private readonly IDbConnection _dbconnection;

        public MechanicDAO(IDbConnection dbconnection)
        {
            _dbconnection = dbconnection;
        }

        public async Task<bool> AddAsync(Mechanic mechanic)
        {
            var sql = "INSERT INTO Mechanic (Id_Person, Specialization_id, CarCategory_id ) " +
                     "VALUES (@Id_Person, @Specialization_id, @CarCategory_id)";
            var result = await _dbconnection.ExecuteAsync(sql, mechanic);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int Id_Person)
        {
            var sql = "DELETE FROM Mechanic WHERE Id_Person = @Id_Person";
            var result = await _dbconnection.ExecuteAsync(sql, new { Id_Person = Id_Person });
            return result > 0;
        }

        public async Task<IEnumerable<Mechanic>> GetAllByCategoryAsync(int CarCategory_id)
        {
            var sql = "SELECT * FROM Mechanic WHERE CarCategory_id = @CarCategory_id";
            return await _dbconnection.QueryAsync<Mechanic>(sql, new { CarCategory_id = CarCategory_id });
        }

        public async Task<IEnumerable<Mechanic>> GetAllBySpecializationAsync(int Specialization_id)
        {
            var sql = "SELECT * FROM Mechanic WHERE Specialization_id = @Specialization_id";
            return await _dbconnection.QueryAsync<Mechanic>(sql, new { Specialization_id = Specialization_id });
        }

        public async Task<IEnumerable<Mechanic>> GetAllMechanicsAsync()
        {
            var sql = @"SELECT * FROM Mechanic";

            return await _dbconnection.QueryAsync<Mechanic>(sql, new { });
        }

        public async Task<Mechanic> GetByIdAsync(int Id_Person)
        {
            var sql = "SELECT * FROM Mechanic WHERE Id_Person = @Id_Person";
            return await _dbconnection.QuerySingleOrDefaultAsync<Mechanic>(sql, new { Id_Person = Id_Person });
        }

        public async Task<bool> UpdateAsync(Mechanic mechanic)
        {
            var sql = "UPDATE Mechanic SET Specialization_id = @Specialization_id, CarCategory_id = @CarCategory_id " +
                     "WHERE Id_Person = @Id_Person";
            var result = await _dbconnection.ExecuteAsync(sql, mechanic);
            return result > 0;
        }
    }
}
