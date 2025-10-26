using Jīao.Entities;
using Jīao.Models.Dtos;
using Jīao.Models.Enum;
using Jīao.Repositories.Interfaces;
using Jīao.Service.Interfaces;

namespace Jīao.Service.Implementations
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        bool IUserService.CheckIfUserExists(int userId)
        {
            return _userRepository.CheckIfUserExists(userId);
        }

        public UserDto Create(CreateAndUpdateUserDto dto)
        {
            User newUser = new User()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Password = dto.Password,
                Email = dto.Email,
                Address = dto.Address,
                State = State.Active,
            };
            int newId = _userRepository.Create(newUser);
            var newUserDto = new UserDto(newId, newUser.FirstName, newUser.LastName, newUser.Email,newUser.Address, newUser.State);
            return newUserDto;
        }

        public IEnumerable<UserDto> GetAll()
        {
            //Acá hacemos un select para convertir todas las entidades User a GetUserByIdDto para no mandar todos los Contacts de cada user ni tampoco la contraseña y solo enviar la info básica del usuario.
            return _userRepository.GetAll().Select(u => new UserDto(u.Id, u.FirstName, u.LastName,u.Address, u.Email, u.State));
        }


        public GetUserByIdDto? GetById(int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user is not null)
            {
                return new GetUserByIdDto(user.Id, user.FirstName, user.LastName, user.Email, user.Address, user.State);
            }
            return null;
        }

        void IUserService.RemoveUser(int userId)
        {
            _userRepository.RemoveUser(userId);
        }

        void IUserService.Update(CreateAndUpdateUserDto dto, int userId)
        {
            var user = new User()
            {
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                Password = dto.Password,
            };
            _userRepository.Update(user, userId);
        }
    }
}
