using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcExample.Application.AuthorOperations.Queries.GetAuthorForAccount
{
    public class GetAuthorForAccountQuery:IRequest<ICollection<AuthorForAccountVM>>
    {
       public int Id { get; set; }
    }
}
