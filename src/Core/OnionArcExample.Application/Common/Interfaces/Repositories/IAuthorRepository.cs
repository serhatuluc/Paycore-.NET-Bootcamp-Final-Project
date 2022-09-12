using OnionArcExample.Domain;
using System.Threading.Tasks;

namespace OnionArcExample.Application.Interfaces.Repositories
{
    public interface IAuthorRepository :IGenericRepository<Author>
    {
        Task<Account> GetAccount(int id);
    }
}
