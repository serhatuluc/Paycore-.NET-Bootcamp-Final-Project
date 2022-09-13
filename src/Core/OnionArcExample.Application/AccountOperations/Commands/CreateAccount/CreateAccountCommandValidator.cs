using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcExample.Application.AccountOperations.Commands.CreateAccount
{
    public class CreateAccountCommandValidator:AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).MinimumLength(3).WithMessage("Fisrt name can not be empty. Length should be between 3-50 character.");
            RuleFor(x => x.UserName).NotEmpty().MaximumLength(50).MinimumLength(3).WithMessage("Last name can not be empty. Length should be between 3-50 character.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().Matches("/^[A-F0-9]{32}/i");
        }
    }
}
