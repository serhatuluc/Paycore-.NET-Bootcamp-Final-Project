using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcExample.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery :IRequest<AuthorDetailVm>
    {
        public int Id { get;set;}
    }
}
