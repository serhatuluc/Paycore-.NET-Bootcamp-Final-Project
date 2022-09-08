using NHibernate;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;


namespace OnionArcExample.Persistence.Repository
{
    public class TokenRepository:HibernateRepository<Account>,ITokenRepository
    {
        private readonly ISession session;
        private ITransaction transaction;

        public TokenRepository(ISession session) : base(session)
        {
            this.session = session;
        }
    }
}
