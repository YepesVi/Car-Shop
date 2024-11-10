using Entity;

namespace CarShop.Service
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllCars();

    }
}
