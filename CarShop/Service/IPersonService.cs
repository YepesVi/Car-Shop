using Entity;

namespace CarShop.Service
{
    public interface IPersonService
    {
        Task<Person> GetByIdAsync(int id);

        Task<Person> GetByUserIdAsync(int id);

        Task<Person> GetByDocumentAsync(long document);
    }
}
