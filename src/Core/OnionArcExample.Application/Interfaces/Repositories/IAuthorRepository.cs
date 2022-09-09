using OnionArcExample.Domain;
using System.Threading.Tasks;

namespace OnionArcExample.Application.Interfaces.Repositories
{
    public interface IAuthorRepository :IRepository<Author>
    {
        Task<Account> GetAccount(int id);
    }
}
