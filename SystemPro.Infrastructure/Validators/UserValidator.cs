using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using SystemPro.Core.DTOs;

namespace SystemPro.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName)
                .NotNull()
                .Length(1, 100);

            RuleFor(user => user.LastName)
                .NotNull()
                .Length(1, 100);

            
        }
    }
}
