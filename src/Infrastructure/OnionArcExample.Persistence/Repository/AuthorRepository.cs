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
    public class AuthorRepository:HibernateRepository<Author>,IAuthorRepository
    {
        private readonly ISession session;
        private ITransaction transaction;

        public AuthorRepository(ISession session) : base(session)
        {
            this.session = session;
        }
    }
}
