using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICarCategory
    {
        Task<IEnumerable<CarCategory>> GetAllCategoriesAsync();
        Task<CarCategory> GetByIdAsync(int id);

    }
}
