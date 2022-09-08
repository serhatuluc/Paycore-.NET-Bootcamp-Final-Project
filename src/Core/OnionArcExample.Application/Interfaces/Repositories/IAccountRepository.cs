using OnionArcExample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcExample.Application.Interfaces.Repositories
{
    public interface IAccountRepository:IHibernateRepository<Account>
    {
    }
}
