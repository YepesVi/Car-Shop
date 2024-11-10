using Entity;
using Entity.ViewModels;

namespace CarShop.Service
{
    public interface IUserService
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<User> GetUserByIdAsync(int id);
        Task<bool> LoginAsync(string email, string password);

        Task<bool> RegisterAsync(User user, Person person);

        Task<List<UserPersonViewModel>> GetAllUsersWithPersonsAsync();

        Task<bool> UpdateUserAsync(UpdateUserViewModel model);

        Task<bool> AddUserAsync(UpdateUserViewModel model);

        Task<bool> DeleteUserByIdAsync(int id);
    }
}
