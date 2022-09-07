using OnionArcExample.Domain;
using System.Threading.Tasks;

namespace OnionArcExample.Application
{
    public interface IStoreService  : IBaseService<StoreDto, Store>
    {
        Task<BaseResponse<StoreDto>> IncrementInventory(int id);
    }
}
