using NHibernate;
using NHibernate.Linq;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;
using System.Threading.Tasks;

namespace OnionArcExample.Persistence.Repository
{
    public class AuthorRepository:GenericRepository<Author>,IAuthorRepository
    {
        private readonly ISession session;
        private ITransaction transaction;

        public AuthorRepository(ISession session) : base(session)
        {
            this.session = session;
         
        }
        public async Task<Account> GetAccount(int id)
        {
            var account =await session.Query<Account>().FirstOrDefaultAsync(x=>x.Id == id);
            return account;
        } 

    }
}
