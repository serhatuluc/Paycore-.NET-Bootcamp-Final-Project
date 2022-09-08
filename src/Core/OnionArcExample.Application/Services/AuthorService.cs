using AutoMapper;
using NHibernate;
using OnionArcExample.Application;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;

namespace OnionArcExample.Persistence
{
    public class AuthorService : BaseService<AuthorDto, Author>, IAuthorService
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IAuthorRepository hibernateRepository;

        public AuthorService(ISession session, IMapper mapper,IAuthorRepository hibernateRepository) : base(session, mapper,hibernateRepository)
        {
            this.session = session;
            this.mapper = mapper;
            this.hibernateRepository = hibernateRepository;

        }

     
    }
}
