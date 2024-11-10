using Entity;
using Repository;

namespace CarShop.Service
{
    public class AuxiliaryListsService : IAuxiliaryListsService
    {
        private readonly ILogger<AuxiliaryListsService> _logger;
        private readonly IDocumentTypes _IDocumentTypes;
        private readonly ICarCategory _ICarCategory;
        private readonly ISpecializations _ISpecializations;
        private readonly IRoles _IRoles;

        public AuxiliaryListsService(ILogger<AuxiliaryListsService> logger, IDocumentTypes iDocumentTypes, ICarCategory iCarCategory, ISpecializations iSpecializations, IRoles iRoles)
        {
            _logger = logger;
            _IDocumentTypes = iDocumentTypes;
            _ICarCategory = iCarCategory;
            _ISpecializations = iSpecializations;
            _IRoles = iRoles;
        }

        public async Task<IEnumerable<CarCategory>> GetAllCarCategories()
        {
            return await _ICarCategory.GetAllCategoriesAsync();
        }

        public async Task<IEnumerable<DocumentTypes>> GetAllDocumentTypes()
        {
            return await _IDocumentTypes.GetAllDocumentTypesAsync();
        }

        public async Task<IEnumerable<Specializations>> GetAllSpecializations()
        {
            return await _ISpecializations. GetAllSpecializationsAsync();
        }

        public async Task<IEnumerable<Roles>> GetAllRoles()
        {
            return await _IRoles.GetAllRolesAsync();
        }

    }
}
