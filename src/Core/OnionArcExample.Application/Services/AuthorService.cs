using AutoMapper;
using OnionArcExample.Application;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;
using System.Threading.Tasks;

namespace OnionArcExample.Application
{
    public class AuthorService : BaseService<AuthorDto, Author>, IAuthorService
    {
        protected readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IMapper mapper, IUnitOfWork _unitOfWork) : base(mapper,_unitOfWork.Author)
        {
            this._mapper = mapper;
            this._unitOfWork = _unitOfWork;

        }
        public virtual async Task<BaseResponse<Account>> GetAccountById(int id)
        {
            var account = await _unitOfWork.Author.GetAccount(id);
            return new BaseResponse<Account>(account);
        }


    }
}
