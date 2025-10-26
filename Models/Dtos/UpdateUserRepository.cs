using Jīao.Entities;
using Jīao.Models.Enum;

namespace Jīao.Models.Dtos
{
    public record UpdateUserRepository(int Id ,string Address ,string Email ,State State ,string FirstName,string LastName);
}
