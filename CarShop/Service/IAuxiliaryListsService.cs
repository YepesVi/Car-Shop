using Entity;

namespace CarShop.Service
{
    public interface IAuxiliaryListsService
    {
        Task<IEnumerable<DocumentTypes>> GetAllDocumentTypes();
        Task<IEnumerable<CarCategory>> GetAllCarCategories();
        Task<IEnumerable<Specializations>> GetAllSpecializations();

        Task<IEnumerable<Roles>> GetAllRoles();
    }
}
