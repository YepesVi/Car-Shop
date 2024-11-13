using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ISpecializations
    {
        Task<IEnumerable<Specializations>> GetAllSpecializationsAsync();
        Task<Specializations> GetByIdAsync(int id);
    }
}
