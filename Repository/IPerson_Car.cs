using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IPerson_Car
    {
        Task<IEnumerable<Person_Car>> GetAllPersonCarAsync();

        Task<Person_Car> GetPersonCarByCarIdAsync(int id);

        Task<IEnumerable<Person_Car>> GetPersonCarByPersonIdAsync(int id);
        Task<bool> InsertPersonCarAsync(Person_Car personCar);

        Task<bool> UpdatePersonCarByCarIdAsync(Person_Car personCar);

        Task<bool> DeletePersonCarAsync(int id);
    }
}
