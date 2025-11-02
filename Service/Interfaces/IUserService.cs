using Jīao.Entities;
using Jīao.Models.Dtos;

namespace Jīao.Service.Interfaces
{
    public interface IUserService
    {
        public bool CheckIfUserExists(int userId);
        public UserDto Create(CreateAndUpdateUserDto dto);
        public IEnumerable<UserDto> GetAll();
        public GetUserByIdDto? GetById(int userId);
        public void RemoveUser(int userId);
        public void Update(CreateAndUpdateUserDto dto, int userId);
        public User? ValidateUser(AuthenticationRequestDto authRequestBody);
    }
}
