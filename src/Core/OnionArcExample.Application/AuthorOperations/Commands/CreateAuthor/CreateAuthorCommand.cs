using MediatR;
using OnionArcExample.Domain;

namespace OnionArcExample.Application.AuthorOperations
{
    public class CreateAuthorCommand:IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AccountId { get; set; }
    }
}
