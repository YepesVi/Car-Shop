using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IService
    {
        Task<IEnumerable<Service>> GetAllServicesAsync();

        Task<bool> AddServiceAsync(Service service);

        Task<Service> GetServicesByIdAsync(int Id);
        Task<IEnumerable<Service>> GetServiceListByIDAsync(int Id);

        Task<bool> UpdateServiceAsync(Service service);

        Task<bool> DeleteServiceAsync(int Id);

        Task<IEnumerable<Service>> GetServiceByCarIDAsync(int Car_d);

        Task<Service> GetActiveServiceAsync(int Car_id);

        Task<IEnumerable<Service>> GetServicesByCarCategoryAsync(int categoryId);

    }
}
