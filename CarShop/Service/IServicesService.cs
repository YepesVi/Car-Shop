using Entity;
using Entity.ViewModels;

namespace CarShop.Service
{
    public interface IServicesService
    {
        Task<IEnumerable<Entity.Service>> GetServicesByCarCategoryAsync(int carCategory);
        Task<IEnumerable<ServicePlateViewModel>> GetServicePlateViewModelsByCarCategoryAsync(int carCategory);
        Task<IEnumerable<Entity.Service>> GetAllServicesAsync();

        Task<IEnumerable<Entity.Service>> GetServiceByCarIDAsync(int Car_d);
        Task<IEnumerable<ServicePlateViewModel>> GetServiceWithCarPlateByCarIdAsync(int carId);
        Task<IEnumerable<ServicePlateViewModel>> GetServiceWithCarPlateByServiceIdAsync(int serviceId);

        Task<Entity.Service> GetActiveServiceAsync(int Car_id);

        Task<bool> AddServiceAsync(Entity.Service service);

        Task<bool> FinishedServiceAsync(Entity.Service service);
        Task<Entity.Service> GetServicesByIdAsync(int Id);

        //Parts

        Task<bool> AddPartAsync(Part part);

        Task<IEnumerable<Part>> GetAllPartsByServiceAsync(int serviceId);

        Task<bool> UpdatePartAsync(Part part);
        Task<bool> DeletePartAsync(int id);

        //Labors

        Task<IEnumerable<Labor>> GetAllLaborsByServiceAsync(int serviceId);

        Task<IEnumerable<Labor>> GetAllLaborsByMechaniceAsync(int mechanicId);

        Task<bool> AddLaborAsync(Labor labor);
        Task<bool> UpdateLaborAsync(Labor labor);
        Task<bool> DeleteLaborAsync(int id);



    }
}
