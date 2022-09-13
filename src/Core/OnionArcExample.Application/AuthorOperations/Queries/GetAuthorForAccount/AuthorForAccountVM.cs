using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcExample.Application.AuthorOperations.Queries.GetAuthorForAccount
{
    public class AuthorForAccountVM
    {
        public int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int AccountId { get; set; }
    }
}
