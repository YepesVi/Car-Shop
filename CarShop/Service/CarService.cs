using Entity;
using Repository;



namespace CarShop.Service
{
    public class CarService:ICarService
    {
        private readonly ILogger<CarService> _logger;
        private readonly ICars _ICars;

        public CarService(ILogger<CarService> logger, ICars iCars)
        {
            _logger = logger;
            _ICars = iCars;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _ICars.GetAllCars();
        }

       
    }
}
