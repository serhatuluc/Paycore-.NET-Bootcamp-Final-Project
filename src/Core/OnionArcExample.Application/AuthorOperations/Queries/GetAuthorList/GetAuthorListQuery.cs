using MediatR;
using OnionArcExample.Domain;
using System.Collections.Generic;

namespace OnionArcExample.Application.AuthorOperations.Queries.GetAuthorList
{
    public class GetAuthorListQuery : IRequest<IEnumerable<GetAuthorListQuery>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
