using OnionArcExample.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnionArcExample.Domain
{
    public interface IBaseService<Dto, Entity>
    {
        Task<BaseResponse<Dto>> GetById(int id);
        BaseResponse<IEnumerable<Dto>> GetAll();
        Task<BaseResponse<Dto>> Insert(Dto insertResource);
        Task<BaseResponse<Dto>> Update(int id, Dto updateResource);
        Task<BaseResponse<Dto>> Remove(int id);
    }
}
