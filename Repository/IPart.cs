using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IPart
    {
        Task<IEnumerable<Part>> GetAllPartsAsync();
        Task<IEnumerable<Part>> GetAllPartsByServiceAsync(int serviceId);
        Task<bool> AddAsync(Part part);
        Task<bool> UpdateAsync(Part part);
        Task<bool> DeleteAsync(int id);
        Task<Part> GetByIdAsync(int id);

    }
}
