
using Entity;
using Entity.ViewModels;
using Repository;

namespace CarShop.Service
{
    public class ServicesService : IServicesService
    {
        private readonly ILogger<ServicesService> _logger;
        private readonly IService _IService;
        private readonly IPart _IPart;
        private readonly ILabor _ILabor;
        private readonly ICars _ICars;
        private readonly ICarCategory _ICarCategory;

        public ServicesService(ILogger<ServicesService> logger, IService iService, IPart iPart, ILabor iLabor, ICars iCars, ICarCategory iCarCategory)
        {
            _logger = logger;
            _IService = iService;
            _IPart = iPart;
            _ILabor = iLabor;
            _ICars = iCars;
            _ICarCategory = iCarCategory;
        }

        public async Task<bool> AddLaborAsync(Labor labor)
        {
           
           var result = await _ILabor.AddAsync(labor);
            if (result)
            {
                await updatePriceService(labor.Service_id);
                return result;
            }
            return false;
            
        }

        public async Task<bool> AddPartAsync(Part part)
        {
           
            var result =  await _IPart.AddAsync(part); 
            if (result)
            {
                await updatePriceService(part.Service_id);
                return result;
            }
            return false;
        }

        public async Task<bool> AddServiceAsync(Entity.Service service)
        {
            service.EntranceDate = DateTime.Now;
            service.FinishedDate = null;
            return await _IService.AddServiceAsync(service);
        }

        public async Task<bool> DeleteLaborAsync(int id)
        {
            var labor = await _ILabor.GetByIdAsync(id);
            if (labor != null)
            { 

                var result = await _ILabor.DeleteAsync(id);
                if (result)
                {
                    await updatePriceService(labor.Service_id);
                    return result;
                }

            }
            return false;

        }

        public async Task<bool> DeletePartAsync(int id)
        {
            var part = await _IPart.GetByIdAsync(id);
            if (part != null)
            {

                var result = await _IPart.DeleteAsync(id);
                if (result)
                {
                    await updatePriceService(part.Service_id);
                    return result;
                }

            }
            return false;
        }

        public async Task<bool> FinishedServiceAsync(Entity.Service service)
        {
            service.FinishedDate = DateTime.Now;
            return await _IService.UpdateServiceAsync(service);
        }

        public async Task<Entity.Service> GetActiveServiceAsync(int Car_id)
        {
            return await _IService.GetActiveServiceAsync(Car_id);
        }

        public async Task<IEnumerable<Labor>> GetAllLaborsByMechaniceAsync(int mechanicId)
        {
            return await _ILabor.GetAllLaborsByMechaniceAsync(mechanicId);
        }

        public async Task<IEnumerable<Labor>> GetAllLaborsByServiceAsync(int serviceId)
        {
            return await _ILabor.GetAllLaborsByServiceAsync(serviceId);
        }

        public async Task<IEnumerable<Part>> GetAllPartsByServiceAsync(int serviceId)
        {
            return await _IPart.GetAllPartsByServiceAsync(serviceId);
        }

        public async Task<IEnumerable<Entity.Service>> GetAllServicesAsync()
        {
            return await _IService.GetAllServicesAsync();
        }

        public async Task<IEnumerable<Entity.Service>> GetServiceByCarIDAsync(int Car_d)
        {
            return await _IService.GetServiceByCarIDAsync(Car_d);
        }

        public async Task<IEnumerable<Entity.Service>> GetServicesByCarCategoryAsync(int carCategory)
        {
            return await _IService.GetServicesByCarCategoryAsync (carCategory); 
        }

        public async Task<IEnumerable<ServicePlateViewModel>> GetServicePlateViewModelsByCarCategoryAsync(int carCategory)
        {
            // Fetch services by car category
            var services = await _IService.GetServicesByCarCategoryAsync(carCategory);

            // Initialize a list to hold the view models
            var servicePlateViewModels = new List<ServicePlateViewModel>();

            // Loop through each service and map to ServicePlateViewModel
            foreach (var service in services)
            {
                // Assuming you have a method to get the car details by its ID
                var car = await _ICars.GetCarByIdAsync(service.Car_id); // Ensure _ICars is injected into your service

                // Create and populate the ServicePlateViewModel
                var viewModel = new ServicePlateViewModel
                {
                    Id = service.Id,
                   
                    EntranceDate = service.EntranceDate,
                    FinishedDate = service.FinishedDate,
                    TotalPrice = service.TotalPrice,
                    Plate = car.Plate 
                };

                // Add the view model to the list
                servicePlateViewModels.Add(viewModel);
            }

            return servicePlateViewModels; // Return the list of ServicePlateViewModel
        }

        public async Task<Entity.Service> GetServicesByIdAsync(int Id)
        {
            return await _IService.GetServicesByIdAsync(Id);
        }

        public async Task<bool> UpdateLaborAsync(Labor labor)
        {
            return await _ILabor.UpdateAsync(labor);
        }

        public async Task<bool> UpdatePartAsync(Part part)
        {
            return await _IPart.UpdateAsync(part);
        }

        public async Task updatePriceService(int serviceId)
        {
            // Obtener el servicio por su ID
            var service = await _IService.GetServicesByIdAsync(serviceId);
            if (service == null)
            {
                throw new Exception("Service not found.");
            }

            // Obtener las partes relacionadas con el servicio
            var parts = await _IPart.GetAllPartsByServiceAsync(serviceId);

            // Obtener las labores relacionadas con el servicio
            var labors = await _ILabor.GetAllLaborsByServiceAsync(serviceId);

            // Obtener el carro asociado al servicio
            var car = await _ICars.GetCarByIdAsync(service.Car_id); // Usar el método de CarsDAO
            if (car == null)
            {
                throw new Exception("Car not found.");
            }

            // Obtener la categoría del carro para obtener el precio por hora
            var carCategory = await _ICarCategory.GetByIdAsync(car.CarCategory_id); // Asumiendo que existe un método para obtener la categoría

            // Calcular el costo total de las partes
            decimal totalPartsCost = parts.Sum(part => part.Price * part.Quantity);

            // Calcular el costo total de las labores
            decimal totalLaborCost = labors.Sum(labor => labor.HoursWorked * carCategory.LaborPriceHour);

            // Sumar ambos costos para obtener el total
            service.TotalPrice = totalPartsCost + totalLaborCost;

            // Actualizar el servicio con el nuevo precio total
            await _IService.UpdateServiceAsync(service);
        }

        public async Task<IEnumerable<ServicePlateViewModel>> GetServiceWithCarPlateByCarIdAsync(int carId)
        {
            // Fetch services by car ID
            var services = await _IService.GetServiceByCarIDAsync(carId);

            // Initialize a list to hold the view models
            var servicePlateViewModels = new List<ServicePlateViewModel>();

            // Loop through each service and map to ServicePlateViewModel
            foreach (var service in services)
            {
                // Assuming you have a method to get the car details by its ID
                var car = await _ICars.GetCarByIdAsync(service.Car_id); // Make sure _ICars is injected into your service

                if (car != null)
                {
                    var viewModel = new ServicePlateViewModel
                    {
                        Id = service.Id,
                        EntranceDate = service.EntranceDate,
                        FinishedDate = service.FinishedDate,
                        TotalPrice = service.TotalPrice,
                        Plate = car.Plate // Set the plate from the car object
                    };

                    servicePlateViewModels.Add(viewModel);
                }
            }

            return servicePlateViewModels;
        }
        public async Task<IEnumerable<ServicePlateViewModel>> GetServiceWithCarPlateByServiceIdAsync(int serviceId)
        {
            // Fetch the service by its ID
            var service = await _IService.GetServicesByIdAsync(serviceId);

            // Check if the service exists
            if (service == null)
            {
                return null; // or throw an exception, depending on your error handling strategy
            }

            // Assuming you have a method to get the car details by its ID
            var car = await _ICars.GetCarByIdAsync(service.Car_id); // Make sure _ICars is injected into your service
            var servicePlateViewModels = new List<ServicePlateViewModel>();
            // Create and return the ServicePlateViewModel
            var viewModel = new ServicePlateViewModel
            {
                Id = service.Id,
                EntranceDate = service.EntranceDate,
                FinishedDate = service.FinishedDate,
                TotalPrice = service.TotalPrice,
                Plate = car?.Plate // Use null-conditional operator in case car is null
            };
            servicePlateViewModels.Add(viewModel);

            return servicePlateViewModels;
        }
    }
}
