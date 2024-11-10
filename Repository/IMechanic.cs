using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IMechanic
    {
        Task<IEnumerable<Mechanic>> GetAllMechanicsAsync();
        Task<Mechanic> GetByIdAsync(int id);
        Task<bool> AddAsync(Mechanic mechanic);
        Task<bool> UpdateAsync(Mechanic mechanic);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Mechanic>> GetAllByCategoryAsync(int category_id);
        Task<IEnumerable<Mechanic>> GetAllBySpecializationAsync(int specialization_id);


    }
}
