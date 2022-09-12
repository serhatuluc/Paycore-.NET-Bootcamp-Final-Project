using OnionArcExample.Domain;

namespace OnionArcExample.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class AuthorDetailVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Account Account { get; set; }
    }
}