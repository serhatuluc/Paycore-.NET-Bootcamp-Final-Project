using FluentValidation;

namespace OnionArcExample.Application.AuthorOperations
{
    public class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50).MinimumLength(3).WithMessage("Fisrt name can not be empty. Length should be between 3-50 character.");
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50).MinimumLength(3).WithMessage("Last name can not be empty. Length should be between 3-50 character.");
        }
    }
}
