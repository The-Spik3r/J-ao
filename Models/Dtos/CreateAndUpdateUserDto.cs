﻿using Jīao.Models.Enum;

namespace Jīao.Models.Dtos
{
    public record CreateAndUpdateUserDto
    {
        public string Address { get; init; }
        public string Email { get; init; }
        public State State { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Password { get; init; }

        public CreateAndUpdateUserDto() { }
    }
}
