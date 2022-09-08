using NHibernate;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcExample.Persistence.Repository
{
    public class AccountRepository:HibernateRepository<Account>,IAccountRepository
    {
        private readonly ISession session;
        private ITransaction transaction;

        public AccountRepository(ISession session):base(session)
        {
            this.session = session;
        }

    }
}
