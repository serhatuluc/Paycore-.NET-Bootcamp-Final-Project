using AutoMapper;
using OnionArcExample.Application;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;

namespace OnionArcExample.Persistence
{
    public class AccountService : BaseService<AccountDto, Account>, IAccountService
    {
        protected readonly IMapper mapper;
        protected readonly IAccountRepository accountRepository;

        public AccountService(IMapper mapper, IAccountRepository accountRepository) : base(mapper,accountRepository)
        {
            this.mapper = mapper;
            this.accountRepository = accountRepository;
        }


      
    }
}
