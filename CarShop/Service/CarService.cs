using Entity;
using Entity.ViewModels;
using Repository;

namespace CarShop.Service
{
    public class CarService:ICarService
    {
        private readonly ILogger<CarService> _logger;
        private readonly ICars _ICars;
        private readonly IPerson_Car _Person;
        private readonly ICarCategory _CarCategory;

        public CarService(ILogger<CarService> logger, ICars iCars, IPerson_Car person, ICarCategory carCategory)
        {
            _logger = logger;
            _ICars = iCars;
            _Person = person;
            _CarCategory = carCategory;
        }

        public async Task<bool> AddCarWithOwner(int Person_id, Car car)
        {
            
            var carId = await _ICars.InsertCarAsync(car);
            if(carId != 0)
            {
                Person_Car owns = new Person_Car();
                owns.Car_id = carId;
                owns.Person_id = Person_id;
                return await _Person.InsertPersonCarAsync(owns);
            }
            return false;
        }



        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _ICars.GetAllCarsAsync();
        }

        public async Task<List<CarsViewModel>> GetAllCarsWithCategoriesAsync(int Person_id)
        {
            // Obtener los coches asociados a la persona
            var personCarRecords = await _Person.GetPersonCarByPersonIdAsync(Person_id);
            if (personCarRecords == null || !personCarRecords.Any())
            {
                return new List<CarsViewModel>(); // Retornar una lista vacía si no hay registros
            }

            // Obtener todos los IDs de coches
            var carIds = personCarRecords.Select(pc => pc.Car_id).ToList();

            // Obtener todos los coches
            var allCars = await _ICars.GetAllCarsAsync();
            var ownedCars = allCars.Where(car => carIds.Contains(car.Id)).ToList();

            // Obtener todas las categorías de coches
            var carCategories = await _CarCategory.GetAllCategoriesAsync();

            // Combinar coches y categorías en el CarsViewModel
            var carsViewModels = ownedCars.Select(car => new CarsViewModel
            {
                Id = car.Id,
                Plate = car.Plate,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                CarCategory = carCategories.FirstOrDefault(cc => cc.Id == car.CarCategory_id)?.Category.ToString() // Cambia 'CategoryName' al nombre correcto de la propiedad
            }).ToList();

            return carsViewModels; // Devuelve la lista de modelos de vista
        }

        public async Task<Car> GetCarByPlateAsync(string plate)
        {
            return await _ICars.GetCarByPlateAsync(plate);
        }

        public async Task<IEnumerable<Car>> GetCarsByOwner(int Person_id)
        {
            // Obtener todos los registros de Person_Car relacionados con el ID de la persona
            var personCarRecords = await _Person.GetPersonCarByPersonIdAsync(Person_id);

            // Si no hay registros, devolver una lista vacía
            if (personCarRecords == null || !personCarRecords.Any())
            {
                return Enumerable.Empty<Car>();
            }

            // Obtener todos los IDs de coches asociados a la persona
            var carIds = personCarRecords.Select(pc => pc.Car_id).ToList();

            // Obtener todos los coches
            var allCars = await _ICars.GetAllCarsAsync();

            // Filtrar los coches por los IDs obtenidos
            var ownedCars = allCars.Where(car => carIds.Contains(car.Id)).ToList();

            return ownedCars; // Devuelve la lista filtrada
        }

        public async Task<bool> updatePersonCar(int person_id, int car_id)
        {
            Person_Car owning = new Person_Car();
            owning.Person_id = person_id;
            owning.Car_id = car_id;
            var result= await _Person.UpdatePersonCarByCarIdAsync(owning);
            if (!result)
            {
                return await _Person.InsertPersonCarAsync(owning);
            }
            return result;
        }

        public async Task<bool> deletePersonCar(int car_id)
        {
           return await _Person.DeletePersonCarAsync(car_id);
        }

        public async Task<bool> updateCarAsync(Car car)
        {
            return await _ICars.UpdateCarAsync(car);
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _ICars.GetCarByIdAsync(id);
        }

        public async Task<decimal> GetCategoryByCarIdAsync(int car_id)
        {
            var car = await _ICars.GetCarByIdAsync(car_id);
            if (car == null)
            {
                return 0; // O lanzar una excepción si prefieres
            }

            // Obtener la categoría del coche usando el ID de la categoría
            var category = await _CarCategory.GetByIdAsync(car.CarCategory_id);

            // Retornar el nombre de la categoría o null si no se encuentra
            return category.LaborPriceHour; // Asegúrate de que 'Category' es la propiedad correcta que contiene el nombre
        }

        public async Task<int> GetOwnerIdByCarIdAsync(int carId)
        {
            var personCar= await _Person.GetPersonCarByCarIdAsync(carId);
            if (personCar == null)
            {
                return -1;
            }
            else
            {
                return personCar.Person_id;
            }
        }
    }
}
