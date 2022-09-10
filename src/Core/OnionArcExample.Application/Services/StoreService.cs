using AutoMapper;
using OnionArcExample.Application;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;
using System;
using System.Threading.Tasks;

namespace OnionArcExample.Application
{
    public class StoreService : BaseService<StoreDto, Store>, IStoreService
    {
        protected readonly IMapper mapper;
        private readonly IUnitOfWork _unitOfWork;

        public StoreService(IMapper mapper, IUnitOfWork _unitOfWork) : base(mapper,_unitOfWork.Store)
        {
            this.mapper = mapper;
            this._unitOfWork = _unitOfWork;
        }

        public async Task<BaseResponse<StoreDto>> IncrementInventory(int id)
        {
            var tempEntity = await _unitOfWork.Store.GetById(id);
            if (tempEntity is null)
            {
                return new BaseResponse<StoreDto>("Record Not Found");
            }

            tempEntity.Inventory++;

            await _unitOfWork.Store.Update(tempEntity);

            var resource = mapper.Map<Store, StoreDto>(tempEntity);
            return new BaseResponse<StoreDto>(resource);
        }

    }
}
