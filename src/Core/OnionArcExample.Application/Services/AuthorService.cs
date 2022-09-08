using AutoMapper;
using OnionArcExample.Application;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;

namespace OnionArcExample.Persistence
{
    public class AuthorService : BaseService<AuthorDto, Author>, IAuthorService
    {
        protected readonly IMapper mapper;
        protected readonly IAuthorRepository hibernateRepository;

        public AuthorService(IMapper mapper,IAuthorRepository hibernateRepository) : base(mapper,hibernateRepository)
        {
            this.mapper = mapper;
            this.hibernateRepository = hibernateRepository;

        }

     
    }
}
