using NHibernate;
using OnionArcExample.Application;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;

namespace OnionArcExample.Persistence.Repository
{
    public class AccountRepository:GenericRepository<Account>,IAccountRepository
    {
        private readonly ISession session;
        private ITransaction transaction;

        public AccountRepository(ISession session):base(session)
        {
            this.session = session;
        }

    }
}
