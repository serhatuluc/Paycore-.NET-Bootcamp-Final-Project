using AutoMapper;
using OnionArcExample.Application;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;
using System.Threading.Tasks;

namespace OnionArcExample.Application
{
    public class AuthorService : BaseService<AuthorDto, Author>, IAuthorService
    {
        protected readonly IMapper mapper;
        protected readonly IAuthorRepository authorRepository;

        public AuthorService(IMapper mapper,IAuthorRepository authorRepository) : base(mapper,authorRepository)
        {
            this.mapper = mapper;
            this.authorRepository = authorRepository;

        }
        public virtual async Task<BaseResponse<Account>> GetAccountById(int id)
        {
            var account = await authorRepository.GetAccount(id);
            return new BaseResponse<Account>(account);
        }


    }
}
