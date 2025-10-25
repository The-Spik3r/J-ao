using Jīao.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Jīao.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }

        public State State { get; set; } = State.Active;
    }
}
