using AutoMapper;
using OnionArcExample.Application;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;

namespace OnionArcExample.Application
{
    public class AccountService : BaseService<AccountDto, Account>, IAccountService
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork unitOfWork;

        public AccountService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper,unitOfWork.Account)
        {
            this._mapper = mapper;
            this.unitOfWork = unitOfWork;
        }


    }
}
