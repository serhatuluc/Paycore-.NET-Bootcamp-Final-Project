using OnionArcExample.Domain;

namespace OnionArcExample.Application
{
    public interface IStoreService  : IBaseService<StoreDto, Store>
    {
        BaseResponse<StoreDto> IncrementInventory(int id);
    }
}
