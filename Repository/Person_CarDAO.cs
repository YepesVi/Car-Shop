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
    public class Person_CarDAO : IPerson_Car
    {
        private readonly IDbConnection _dbconnection;

        public Person_CarDAO(IDbConnection dbconnection)
        {
            _dbconnection = dbconnection;
        }

        public async Task<bool> DeletePersonCarAsync(int id)
        {

            var sql = "DELETE FROM Person_Car WHERE Car_id = @Car_id";
            var result = await _dbconnection.ExecuteAsync(sql, new { Car_id = id });
            return result > 0;
        }

        public async Task<IEnumerable<Person_Car>> GetAllPersonCarAsync()
        {
            var sql = @"SELECT * FROM Person_Car";

            return await _dbconnection.QueryAsync<Person_Car>(sql, new { });
        }

        public async Task<Person_Car> GetPersonCarByCarIdAsync(int Car_id)
        {
            var sql = "SELECT * FROM Person_Car WHERE Car_id = @Car_id";
            return await _dbconnection.QuerySingleOrDefaultAsync<Person_Car>(sql, new { Car_id = Car_id });
        }

        public async Task<IEnumerable<Person_Car>> GetPersonCarByPersonIdAsync(int Person_id)
        {
            var sql = "SELECT * FROM Person_Car WHERE Person_id = @Person_id";
            return await _dbconnection.QueryAsync<Person_Car>(sql, new { Person_id = Person_id });
        }

        public async Task<bool> InsertPersonCarAsync(Person_Car personCar)
        {
            var sql = @"
                INSERT INTO Person_Car (Person_id, Car_id)
                VALUES (@Person_id, @Car_id)";

            var result = await _dbconnection.ExecuteAsync(sql, personCar);
            return result > 0; // Retorna true si se insertó al menos una fila
        }

        public async Task<bool> UpdatePersonCarByCarIdAsync(Person_Car personCar)
        {
            var sql = "UPDATE Person_Car SET Person_id = @Person_id, Car_id = @Car_id "+
                       " WHERE Car_id = @Car_id";
            var result = await _dbconnection.ExecuteAsync(sql, personCar);
            return result > 0;
        }
    }
}
