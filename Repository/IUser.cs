using Entity;

namespace Repository
{
    public interface IUser
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> ValidateUserAsync(string email, string password);
        Task<bool> RegisterUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<bool> UpdateUserAsync(User user); 
        Task<bool> DeleteUserAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
