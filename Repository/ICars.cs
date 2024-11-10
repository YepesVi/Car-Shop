using Entity;

namespace Repository
{
    public interface ICars
    {
        Task<IEnumerable<Car>> GetAllCars();
    }
}
