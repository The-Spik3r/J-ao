using Jīao.Models.Enum;

namespace Jīao.Models.Dtos
{
    public record GetUserByIdDto(int Id, string FirstName, string LastName, string Address, string Email, State State);
}
