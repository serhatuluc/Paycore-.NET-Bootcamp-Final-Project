using OnionArcExample.Application;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnionArcExample.Domain
{
    public interface IBaseService<Dto, Entity> 
    {
        Task<BaseResponse<IEnumerable<Dto>>> GetAll();
        Task<BaseResponse<Dto>> GetById(int id);
        Task<BaseResponse<Dto>> Insert(Dto dto);
        Task<BaseResponse<Dto>> Remove(int id);
        Task<BaseResponse<Dto>> Update(int id, Dto dto);
    }
}
