using AutoMapper;
using NHibernate;
using OnionArcExample.Application;
using OnionArcExample.Domain;

namespace OnionArcExample.Persistence
{
    public class AuthorService : BaseService<AuthorDto, Author>, IAuthorService
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Author> hibernateRepository;

        public AuthorService(ISession session, IMapper mapper) : base(session, mapper)
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Author>(session);
        }

     
    }
}
