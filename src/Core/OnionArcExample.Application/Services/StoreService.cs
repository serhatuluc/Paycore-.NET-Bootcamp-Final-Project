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
        protected readonly IStoreRepository hibernateRepository;

        public StoreService(IMapper mapper,IStoreRepository hibernateRepository) : base(mapper,hibernateRepository)
        {
            this.mapper = mapper;
            this.hibernateRepository = hibernateRepository;
        }

        public async Task<BaseResponse<StoreDto>> IncrementInventory(int id)
        {
            var tempEntity = await hibernateRepository.GetById(id);
            if (tempEntity is null)
            {
                return new BaseResponse<StoreDto>("Record Not Found");
            }

            tempEntity.Inventory++;

            await hibernateRepository.Update(tempEntity);

            var resource = mapper.Map<Store, StoreDto>(tempEntity);
            return new BaseResponse<StoreDto>(resource);
        }

    }
}
