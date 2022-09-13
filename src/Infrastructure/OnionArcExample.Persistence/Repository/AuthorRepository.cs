using NHibernate;
using NHibernate.Linq;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ICollection<Author>> GetAuthorsforAccount(int id)
        {
            var account = await session.Query<Author>().Where(x=>x.AccountId == id).ToListAsync();
            return account;
        } 

    }
}
