using NHibernate;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;
using System.Threading.Tasks;

namespace OnionArcExample.Persistence.Repository
{
    public class AuthorRepository:GenericRepository<Author>,IAuthorRepository
    {
        private readonly ISession session;
        private ITransaction transaction;
        private readonly IAccountRepository accountRepository;

        public AuthorRepository(ISession session,IAccountRepository accountRepository) : base(session)
        {
            this.session = session;
            this.accountRepository = accountRepository;
        }
        public async Task<Account> GetAccount(int id)
        {
            var account = await accountRepository.GetById(id);
            return account;
        } 

    }
}
