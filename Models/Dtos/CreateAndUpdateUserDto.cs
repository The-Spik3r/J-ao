using Jīao.Models.Enum;

namespace Jīao.Models.Dtos
{
    public record CreateAndUpdateUserDto(string FirstName, string LastName, string Address, string Email, string Password);
}
