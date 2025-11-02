using Jīao.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Jīao.Models.Dtos
{
    public record AuthenticationRequestDto([Required] string Email, [Required] string Password);
}
