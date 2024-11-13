using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ILabor
    {
        Task<IEnumerable<Labor>> GetAllLaborsAsync();
        Task<IEnumerable<Labor>> GetAllLaborsByServiceAsync(int serviceId);
        Task<IEnumerable<Labor>> GetAllLaborsByMechaniceAsync(int mechanicId);
        Task<bool> AddAsync(Labor labor);
        Task<bool> UpdateAsync(Labor labor);
        Task<bool> DeleteAsync(int id);
        Task<Labor> GetByIdAsync(int id);

    }
}
