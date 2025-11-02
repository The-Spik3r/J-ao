using System.ComponentModel.DataAnnotations;

namespace Jīao.Models.Dtos
{
    public record AuthenticationRequestRespositoryDto([Required] string Email, [Required] string Password);
}
