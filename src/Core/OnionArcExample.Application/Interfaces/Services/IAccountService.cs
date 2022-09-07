using OnionArcExample.Domain;

namespace OnionArcExample.Application
{
    public interface IAccountService : IBaseService<AccountDto, Account>
    {
    }
}
