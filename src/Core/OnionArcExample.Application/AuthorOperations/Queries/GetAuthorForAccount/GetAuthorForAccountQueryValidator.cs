using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcExample.Application.AuthorOperations.Queries.GetAuthorForAccount
{
    public class GetAuthorForAccountQueryValidator:AbstractValidator<GetAuthorForAccountQuery>
    {
        public GetAuthorForAccountQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
