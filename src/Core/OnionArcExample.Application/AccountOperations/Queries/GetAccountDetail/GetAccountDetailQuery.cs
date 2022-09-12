using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcExample.Application.AccountOperations.Queries.GetAccountDetail
{
    public class GetAccountDetailQuery:IRequest<AccountDetailVm>
    {
        public int Id { get; set; }
    }
}
