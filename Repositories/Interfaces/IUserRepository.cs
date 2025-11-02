using Jīao.Entities;
using Jīao.Models.Dtos;

namespace Jīao.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public bool CheckIfUserExists(int userId);
        public int Create(User newUser);
        public List<User> GetAll();
        public User? GetById(int userId);
        public void RemoveUser(int userId);
        public void Update(User updatedUser, int userId);
        public User? ValidateUser(AuthenticationRequestDto authRequestBody);
    }
}
