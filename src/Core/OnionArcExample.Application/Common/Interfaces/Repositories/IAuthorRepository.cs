using OnionArcExample.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnionArcExample.Application.Interfaces.Repositories
{
    public interface IAuthorRepository :IGenericRepository<Author>
    {
        Task<ICollection<Author>> GetAuthorsforAccount(int id);
    }
}
