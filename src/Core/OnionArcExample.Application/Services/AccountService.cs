using AutoMapper;
using NHibernate;
using OnionArcExample.Application;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;

namespace OnionArcExample.Persistence
{
    public class AccountService : BaseService<AccountDto, Account>, IAccountService
    {

        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IAccountRepository accountRepository;

        public AccountService(ISession session, IMapper mapper, IAccountRepository accountRepository) : base(session, mapper,accountRepository)
        {
            this.session = session;
            this.mapper = mapper;
            this.accountRepository = accountRepository;
        }


      
    }
}
