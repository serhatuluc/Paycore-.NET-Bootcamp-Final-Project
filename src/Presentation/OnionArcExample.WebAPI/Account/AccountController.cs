using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnionArcExample.Application;
using OnionArcExample.Domain;

namespace OnionArcExample.WebAPI
{
    [ApiController]
    [Route("api/nhb/[controller]")]
    public class AccountContoller : BaseController<AccountDto, Account>
    {
        private readonly IAccountService accountService;


        public AccountContoller(IAccountService accountService, IMapper mapper) : base(accountService)
        {
            this.accountService = accountService;
        }

    }
}
