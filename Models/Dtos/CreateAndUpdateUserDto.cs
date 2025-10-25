using Jīao.Models.Enum;

namespace Jīao.Models.Dtos
{
    public record CreateAndUpdateUserDto(int? Id,string FirstName, string LastName, string Address, string Email, string Password, State State);
}
