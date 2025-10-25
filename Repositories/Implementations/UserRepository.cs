using Jīao.Entities;
using Jīao.Repositories.Interfaces;

namespace Jīao.Repositories.Implementations
{
    public class UserRepository : IUserRepository

    {
        bool IUserRepository.CheckIfUserExists(int userId)
        {
            throw new NotImplementedException();
        }

        int IUserRepository.Create(User newUser)
        {
            throw new NotImplementedException();
        }

        List<User> IUserRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        User? IUserRepository.GetById(int userId)
        {
            throw new NotImplementedException();
        }

        void IUserRepository.RemoveUser(int userId)
        {
            throw new NotImplementedException();
        }

        void IUserRepository.Update(User updatedUser, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
