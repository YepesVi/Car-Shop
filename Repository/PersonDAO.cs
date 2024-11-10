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
    public class PersonDAO : IPerson
    {
        private readonly IDbConnection _dbconnection;

        public PersonDAO(IDbConnection dbconnection)
        {
            _dbconnection = dbconnection;
        }

        public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
            var sql = @"SELECT * FROM Persons";

            return await _dbconnection.QueryAsync<Person>(sql, new { });
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Persons WHERE Id = @Id";
            return await _dbconnection.QuerySingleOrDefaultAsync<Person>(sql, new { Id = id });
        }



        // Agregar una nueva persona
        public async Task<bool> AddAsync(Person person)
        {
            var sql = "INSERT INTO Persons (User_id, Name, Phone, DocumentType_id, DocumentNumber, Address) " +
                      "VALUES (@User_id, @Name, @Phone, @DocumentType_id, @DocumentNumber, @Address)";
            var result = await _dbconnection.ExecuteAsync(sql, person);
            return result > 0;
        }

        // Actualizar una persona existente
        public async Task<bool> UpdateAsync(Person person)
        {
            var sql = "UPDATE Persons SET User_id = @User_id, Name = @Name, Phone = @Phone, " +
                      "DocumentType_id = @DocumentType_id, DocumentNumber = @DocumentNumber, Address = @Address " +
                      "WHERE Id = @Id";
            var result = await _dbconnection.ExecuteAsync(sql, person);
            return result > 0;
        }

        // Eliminar una persona por ID
        public async Task<bool> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Persons WHERE Id = @Id";
            var result = await _dbconnection.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }

        // Obtener una persona por User_id
        public async Task<Person> GetByUserIdAsync(int userId)
        {
            var sql = "SELECT * FROM Persons WHERE User_id = @User_id";
            return await _dbconnection.QuerySingleOrDefaultAsync<Person>(sql, new { User_id = userId });
        }

        public async Task<Person> GetByDocumentAsync(long DocumentNumber)
        {
            var sql = "SELECT * FROM Persons WHERE DocumentNumber = @DocumentNumber";
            return await _dbconnection.QuerySingleOrDefaultAsync<Person>(sql, new { DocumentNumber = DocumentNumber });
        }
    }
}
