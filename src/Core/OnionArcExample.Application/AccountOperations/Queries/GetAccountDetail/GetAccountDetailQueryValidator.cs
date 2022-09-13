using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcExample.Application.AccountOperations.Queries.GetAccountDetail
{
    public class GetAccountDetailQueryValidator:AbstractValidator<GetAccountDetailQuery>
    {
        public GetAccountDetailQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty();
        }
    }
}
