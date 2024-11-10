using Entity;

namespace Repository
{
    public interface ICars
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(int id);
        Task<Car> GetCarByPlateAsync(string plate);
        Task<int> InsertCarAsync(Car car);
        Task<bool> UpdateCarAsync(Car car);
        Task<bool> DeleteCarAsync(int id);
        Task<IEnumerable<Car>> GetCarsByCategoryAsync(int carCategoryId);

    }
}
