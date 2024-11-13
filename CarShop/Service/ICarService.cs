using Entity;
using Entity.ViewModels;

namespace CarShop.Service
{
    public interface ICarService
    {
        Task<bool> updateCarAsync(Car car);
        Task<IEnumerable<Car>> GetAllCars();

        Task<IEnumerable<Car>> GetCarsByOwner(int Person_id);

        Task<List<CarsViewModel>> GetAllCarsWithCategoriesAsync(int Person_ids);

        Task<bool> AddCarWithOwner(int Person_id, Car car);

        Task<Car> GetCarByPlateAsync(string plate);
        Task<Car> GetCarByIdAsync(int id);

        Task<int> GetOwnerIdByCarIdAsync(int carId);
        Task<bool> updatePersonCar(int person_id, int car_id);

        Task<bool> deletePersonCar(int car_id);
        Task<decimal> GetCategoryByCarIdAsync(int car_id);
    }
}
