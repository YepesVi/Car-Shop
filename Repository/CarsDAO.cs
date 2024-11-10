using Dapper;
using Entity;
using System.Data;

namespace Repository
{
    public class CarsDAO : ICars
    {
        private readonly IDbConnection _dbconnection;

        public CarsDAO(IDbConnection dbconnection)
        {
            _dbconnection = dbconnection;
        }

        async Task<IEnumerable<Car>> ICars.GetAllCarsAsync()
        {
            var sql = @"SELECT * FROM Cars";

            return await _dbconnection.QueryAsync<Car>(sql, new { });

        }

        // Obtener un coche por ID
        public async Task<Car> GetCarByIdAsync(int id)
        {
            var sql = @"SELECT * FROM Cars WHERE Id = @Id";
            return await _dbconnection.QuerySingleOrDefaultAsync<Car>(sql, new { Id = id });
        }

        // Insertar un nuevo coche
        public async Task<int> InsertCarAsync(Car car)
        {
            var sql = @"
                INSERT INTO Cars (Plate, Brand, Model, Year, CarCategory_id)
                VALUES (@Plate, @Brand, @Model, @Year, @CarCategory_id);
                SELECT CAST(SCOPE_IDENTITY() as int)"; // Devuelve el ID del nuevo coche

            return await _dbconnection.ExecuteScalarAsync<int>(sql, car);
        }

        // Actualizar un coche existente
        public async Task<bool> UpdateCarAsync(Car car)
        {
            var sql = @"
                UPDATE Cars 
                SET Plate = @Plate, Brand = @Brand, Model = @Model, Year = @Year, CarCategory_id = @CarCategory_id
                WHERE Id = @Id";

            var affectedRows = await _dbconnection.ExecuteAsync(sql, car);
            return affectedRows > 0; // Retorna true si se actualizó al menos una fila
        }

        // Eliminar un coche por ID
        public async Task<bool> DeleteCarAsync(int id)
        {
            var sql = @"DELETE FROM Cars WHERE Id = @Id";
            var affectedRows = await _dbconnection.ExecuteAsync(sql, new { Id = id });
            return affectedRows > 0; // Retorna true si se eliminó al menos una fila
        }

        public async Task<Car> GetCarByPlateAsync(string plate)
        {
            var sql = @"SELECT * FROM Cars WHERE Plate = @Plate";
            return await _dbconnection.QuerySingleOrDefaultAsync<Car>(sql, new { Plate = plate });
        }

        // Obtener coches por categoría
        public async Task<IEnumerable<Car>> GetCarsByCategoryAsync(int carCategoryId)
        {
            var sql = @"SELECT * FROM Cars WHERE CarCategory_id = @CarCategoryId";
            return await _dbconnection.QueryAsync<Car>(sql, new { CarCategoryId = carCategoryId });
        }
    }
}
