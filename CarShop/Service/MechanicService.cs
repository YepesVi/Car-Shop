using Entity;
using Repository;

namespace CarShop.Service
{
    public class MechanicService : IMechanicService
    {

        private readonly ILogger<UserService> _logger;
        private readonly IMechanic _IMechanic;

        public MechanicService(ILogger<UserService> logger, IMechanic iMechanic)
        {
            _logger = logger;
            _IMechanic = iMechanic;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _IMechanic.DeleteAsync(id);
        }

        public async Task<IEnumerable<Mechanic>> GetByCarCategoryIdAsync(int id)
        {
            return await _IMechanic.GetAllByCategoryAsync(id);
        }

        public async Task<Mechanic> GetByIdAsync(int id)
        {
           return await _IMechanic.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Mechanic>> GetBySpecializationIdAsync(int id)
        {
           return await _IMechanic.GetAllBySpecializationAsync(id);
        }


    }
}
