using Entity;
using Entity.ViewModels;
using Repository;

namespace CarShop.Service
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUser _IUser;
        private readonly IPerson _IPerson;
        private readonly IDocumentTypes _IDocumentTypes;
        private readonly IMechanic _IMechanic;
        public UserService(ILogger<UserService> logger, IUser iUser, IPerson iPerson, IDocumentTypes iDocumentTypes, IMechanic iMechanic)
        {
            _logger = logger;
            _IUser = iUser;
            _IPerson = iPerson;
            _IDocumentTypes = iDocumentTypes;
            _IMechanic = iMechanic;
        }

     

        public async Task<List<UserPersonViewModel>> GetAllUsersWithPersonsAsync()
        {
            var users = await _IUser.GetAllUsersAsync();
            var persons = await _IPerson.GetAllPersonsAsync();
            var DocumentTypes = await _IDocumentTypes.GetAllDocumentTypesAsync();

            // Combinar usuarios y personas en el ViewModel
            var userPersonViewModels = users.Select(User => new UserPersonViewModel
            {
                user = User,
                person = persons.FirstOrDefault(p => p.User_id == User.Id), // Obtener la persona asociada
            }).ToList();

            return userPersonViewModels;
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _IUser.GetUserByEmailAsync(email);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _IUser.GetUserByIdAsync(id);
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            return await _IUser.ValidateUserAsync(email, password);
        }

        public async Task<bool> RegisterAsync(User user, Person person)
        {
            // Primero, registramos el usuario.
            var userCreated = await _IUser.RegisterUserAsync(user);
            if (!userCreated)
            {
                return false; // Registro fallido.
            }

            // Luego, obtenemos el ID del usuario recién creado.
            var createdUser = await _IUser.GetUserByEmailAsync(user.Email);
            if (createdUser == null)
            {
                return false; // No se pudo obtener el usuario creado.
            }

            // Asignamos el ID del usuario a la persona.
            person.User_id = createdUser.Id;

            // Guardamos los datos de la persona.
            var personCreated = await _IPerson.AddAsync(person);

            return personCreated; // Devuelve true si se creó la persona.
        }

        public async Task<bool> UpdateUserAsync(UpdateUserViewModel model)
        {
            var user = await _IUser.GetUserByIdAsync(model.Id);
            if (user == null) { return false; }
            user.Email = model.Email;
            user.Password = model.Password;
            user.Role = model.Role;
            user.Name = model.UserName;
            var userUpdated = await _IUser.UpdateUserAsync(user);
            if (!userUpdated) { return false; }

            var person = await _IPerson.GetByUserIdAsync(user.Id);
            if (person == null) { return false; }
            person.Name = model.Name;
            person.DocumentType_id = model.DocumentType_id;
            person.DocumentNumber = model.DocumentNumber;
            person.Phone = model.Phone;
            person.Address = model.Address;

            var personUpdated = await _IPerson.UpdateAsync(person);
            if (!personUpdated) { return false; }

            var mechanic = await _IMechanic.GetByIdAsync(person.Id);
            if (model.Role == "Mechanic" && model.CarCategory_id != null && model.Specialization_id != null)
            {

                if (mechanic == null)
                {
                    mechanic = new Mechanic();
                    mechanic.Id_Person = person.Id;
                    mechanic.CarCategory_id = (int)model.CarCategory_id;
                    mechanic.Specialization_id = (int)model.Specialization_id;
                    var mechanicCreated = await _IMechanic.AddAsync(mechanic);
                    if (!mechanicCreated) { return false; }
                }
                else
                {
                    mechanic.CarCategory_id = (int)model.CarCategory_id;
                    mechanic.Specialization_id = (int)model.Specialization_id;
                    var mechanicUpdated = await _IMechanic.AddAsync(mechanic);
                    if (!mechanicUpdated) { return false; }
                }
            }
            else
            {
                if (mechanic != null)
                {
                    var MechanicDeleted = await _IMechanic.DeleteAsync(mechanic.Id_Person);
                    if (!MechanicDeleted) { return false; };
                }
            }
            return true;
        }

        public async Task<bool> AddUserAsync(UpdateUserViewModel model)
        {
            var user = new User();
            var person= new Person();

            user.Id = model.Id;
            user.Name = model.UserName;
            user.Password = model.Password;
            user.Email = model.Email;
            user.Role = model.Role;


            person.User_id = model.Id;
            person.Name = model.Name;
            person.Address = model.Address;
            person.Phone = model.Phone; 
            person.DocumentNumber = model.DocumentNumber;
            person.DocumentType_id = model.DocumentType_id;
             
             var registered = await RegisterAsync(user, person);
            
            person = await _IPerson.GetByUserIdAsync(person.User_id);
            
            
            if(model.Role == "Mechanic")
            {
                var mechanic = new Mechanic();
                mechanic.Id_Person = person.Id;
                mechanic.CarCategory_id = (int)model.CarCategory_id;
                mechanic.Specialization_id = (int)model.Specialization_id;

                var createdMechanic = await _IMechanic.AddAsync(mechanic);
                if(!createdMechanic) { return false; }
            }



            return true;
        }

        public async Task<bool> DeleteUserByIdAsync(int id)
        {
            return await _IUser.DeleteUserAsync(id);
        }
    }


}
