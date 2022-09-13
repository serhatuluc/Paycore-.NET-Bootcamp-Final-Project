using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcExample.Application.AccountOperations.Queries.GetAccountList
{
    public class GetAccountListQuery:IRequest<IEnumerable<GetAccountListQuery>>
    {
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Role { get; set; }
        public virtual DateTime LastActivity { get; set; }
    }
}
