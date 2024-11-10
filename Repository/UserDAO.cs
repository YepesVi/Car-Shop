using Dapper;
using Entity;
using System.Data;

namespace Repository
{
    public class UserDAO : IUser
    {
        private readonly IDbConnection _dbconnection;

        public UserDAO(IDbConnection dbconnection)
        {
            _dbconnection = dbconnection;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            string sql = "SELECT * FROM Users WHERE Email = @email";
            return await _dbconnection.QueryFirstOrDefaultAsync<User>(sql, new { email = email });
        }

        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            User user = (User)await GetUserByEmailAsync(email);
            if (user == null) return false;

            return VerifyPassword(password, user.Password);
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            // Password validation
            return password .Equals(storedHash); 
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            // No se realiza hashing en este momento.
            string sql = "INSERT INTO Users (Email, Password, Name, Role) VALUES (@Email, @Password, @Name, @Role)";
            var result = await _dbconnection.ExecuteAsync(sql, user);

            // Devuelve true si se insertó una fila
            return result > 0;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            string sql = "SELECT * FROM Users WHERE Id = @Id";
            return await _dbconnection.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            string sql = "UPDATE Users SET Email = @Email, Password = @Password, Name = @Name, Role = @Role WHERE Id = @Id";
            var result = await _dbconnection.ExecuteAsync(sql, user);

            // Devuelve true si se actualizó al menos una fila
            return result > 0;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            string sql = "DELETE FROM Users WHERE Id = @Id";
            var result = await _dbconnection.ExecuteAsync(sql, new { Id = id });

            // Devuelve true si se eliminó al menos una fila
            return result > 0;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var sql = @"SELECT * FROM Users";

            return await _dbconnection.QueryAsync<User>(sql, new { });
        }
    }
}
