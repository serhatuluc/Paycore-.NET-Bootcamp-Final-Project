using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcExample.Application.Validator
{
    public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {
            RuleFor(b => b.FirstName)
                .NotEmpty().WithMessage("Can not be empty")
                .Length(3, 30).WithMessage("3-30");

            RuleFor(b => b.LastName)
                .NotEmpty().WithMessage("Can not be empty")
                .Length(3, 30).WithMessage("3-30");

        }
    }
}
