using Entity;

namespace CarShop.Service
{
    public interface IMechanicService
    {
        Task<Mechanic> GetByIdAsync(int id);

        Task<IEnumerable<Mechanic>> GetByCarCategoryIdAsync(int id);
        Task<IEnumerable<Mechanic>> GetBySpecializationIdAsync(int id);

        Task<bool> DeleteByIdAsync(int id);     

    }
}
