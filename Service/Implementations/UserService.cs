using Jīao.Entities;
using Jīao.Service.Interfaces;

namespace Jīao.Service.Implementations
{
    public class UserService : IUserService
    {
        bool IUserService.CheckIfUserExists(int userId)
        {
            throw new NotImplementedException();
        }

        int IUserService.Create(User newUser)
        {
            throw new NotImplementedException();
        }

        List<User> IUserService.GetAll()
        {
            throw new NotImplementedException();
        }

        User? IUserService.GetById(int userId)
        {
            throw new NotImplementedException();
        }

        void IUserService.RemoveUser(int userId)
        {
            throw new NotImplementedException();
        }

        void IUserService.Update(User updatedUser, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
