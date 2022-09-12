using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcExample.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator:AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50).MinimumLength(3).WithMessage("Fisrt name can not be empty. Length should be between 3-50 character.");
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50).MinimumLength(3).WithMessage("Last name can not be empty. Length should be between 3-50 character.");
        }
    }
}
