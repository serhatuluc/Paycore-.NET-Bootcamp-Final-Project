using OnionArcExample.Domain;
using System.Threading.Tasks;

namespace OnionArcExample.Application
{
    public interface IAuthorService  : IBaseService<AuthorDto, Author>
    {
        Task<BaseResponse<Account>> GetAccountById(int id);
    }
}
