using Jīao.Models.Enum;

namespace Jīao.Service.Interfaces
{
    public interface IAuthenticationService
    {
        string GenerateTokenJWT(userType UserType, int userId, string firstName, string lastName);

    }
}
