using AutoMapper;
using NHibernate;
using OnionArcExample.Application;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;
using System;
using System.Threading.Tasks;

namespace OnionArcExample.Persistence
{
    public class StoreService : BaseService<StoreDto, Store>, IStoreService
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IStoreRepository hibernateRepository;

        public StoreService(ISession session, IMapper mapper,IStoreRepository hibernateRepository) : base(session, mapper,hibernateRepository)
        {
            this.session = session;
            this.mapper = mapper;
            this.hibernateRepository = hibernateRepository;
        }

        public async Task<BaseResponse<StoreDto>> IncrementInventory(int id)
        {
            try
            {
                var tempEntity = await hibernateRepository.GetById(id);
                if (tempEntity is null)
                {
                    return new BaseResponse<StoreDto>("Record Not Found");
                }

                tempEntity.Inventory++;

                hibernateRepository.BeginTransaction();
                await hibernateRepository .Update(tempEntity);
                await hibernateRepository .Commit();
                hibernateRepository.CloseTransaction();

                var resource = mapper.Map<Store, StoreDto>(tempEntity);
                return new BaseResponse<StoreDto>(resource);
            }
            catch (Exception ex)
            {
                await hibernateRepository .Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<StoreDto>(ex.Message);
            };
        }

    }
}
