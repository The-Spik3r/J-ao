using Jīao.Models.Enum;

namespace Jīao.Models.Dtos
{
    public record GetSellerByIdDto(int Id, string FirstName, string LastName, string Email, State State);
}
