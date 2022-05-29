using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterValidator()
        {
            RuleFor(u => u.FirstName).MinimumLength(2).NotEmpty();
            RuleFor(u => u.Email).EmailAddress().NotEmpty().WithMessage("Email adresinizi kontrol ediniz.");
            RuleFor(u => u.Password).MinimumLength(6).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2).NotEmpty();
        }
    }
}
