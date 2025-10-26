using Jīao.Data;
using Jīao.Entities;
using Jīao.Repositories.Interfaces;

namespace Jīao.Repositories.Implementations
{
    public class UserRepository : IUserRepository

    {
        private JīaoContext _context;

        public UserRepository(JīaoContext context)
        {
            _context = context;
        }

        bool IUserRepository.CheckIfUserExists(int userId)
        {
            return _context.Users.Any(u => u.Id == userId);
        }

        int IUserRepository.Create(User newUser)
        {
            User user = _context.Users.Add(newUser).Entity;
            _context.SaveChanges();
            return user.Id;
        }

        List<User> IUserRepository.GetAll()
        {
            return _context.Users.ToList();
        }

        User? IUserRepository.GetById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }

        void IUserRepository.RemoveUser(int userId)
        {
            _context.Users.Remove(_context.Users.Single(u => u.Id == userId));
            _context.SaveChanges();
        }

        void IUserRepository.Update(User updatedUser, int userId)
        {
            User userToUpdate = _context.Users.First(u =>u.Id == userId);
            userToUpdate.Address = updatedUser.Address;
            userToUpdate.Email = updatedUser.Email;
            userToUpdate.State = updatedUser.State;
            userToUpdate.FirstName = updatedUser.FirstName;
            userToUpdate.LastName = updatedUser.LastName;
            userToUpdate.Password = updatedUser.Password;
            _context.SaveChanges();
        }
    }
}
