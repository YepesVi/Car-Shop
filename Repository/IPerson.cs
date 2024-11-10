using Entity;
using Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IPerson
    {
        Task<IEnumerable<Person>> GetAllPersonsAsync();
        Task<Person> GetByIdAsync(int id);
        Task<bool> AddAsync(Person person);
        Task<bool> UpdateAsync(Person person);
        Task<bool> DeleteAsync(int id);
        Task<Person> GetByUserIdAsync(int userId);

        Task<Person> GetByDocumentAsync(long document);
    }
}
