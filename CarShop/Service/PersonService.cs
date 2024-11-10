using Entity;
using Microsoft.AspNetCore.Mvc.Filters;
using Repository;

namespace CarShop.Service
{
    public class PersonService : IPersonService
    {

        private readonly ILogger<UserService> _logger;
        private readonly IPerson _IPerson;

        public PersonService(ILogger<UserService> logger, IPerson iPerson)
        {
            _logger = logger;
            _IPerson = iPerson;
        }

        public async Task<Person> GetByDocumentAsync(long document)
        {
            return await _IPerson.GetByDocumentAsync(document); 
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _IPerson.GetByIdAsync(id);
        }

        public async Task<Person> GetByUserIdAsync(int id)
        {
            return await _IPerson.GetByUserIdAsync(id);
        }
    }
}
