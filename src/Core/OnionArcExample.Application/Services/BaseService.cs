using AutoMapper;
using OnionArcExample.Application;
using OnionArcExample.Domain;
using OnionArcExample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnionArcExample.Application
{
    public abstract class BaseService<Dto, Entity> : IBaseService<Dto, Entity> where Entity : BaseEntity
    {
        protected readonly IMapper mapper;
        protected readonly IRepository<Entity> repository;


        public BaseService(IMapper mapper,IRepository<Entity> repository) : base()
        {
            this.mapper = mapper;
            this.repository = repository;

        }


        public virtual async Task<BaseResponse<IEnumerable<Dto>>> GetAll()
        {
            var tempEntity =await repository.GetAll();
            var result = mapper.Map<IEnumerable<Entity>, IEnumerable<Dto>>(tempEntity);
            return new BaseResponse<IEnumerable<Dto>>(result);
        }

        public virtual async Task<BaseResponse<Dto>> GetById(int id)
        {
            var tempEntity = await repository.GetById(id);
            var result = mapper.Map<Entity, Dto>(tempEntity);
            return new BaseResponse<Dto>(result);
        }

        public virtual async Task<BaseResponse<Dto>> Insert(Dto insertResource)
        {
            var tempEntity = mapper.Map<Dto, Entity>(insertResource);
            await repository.Create(tempEntity);
            return new BaseResponse<Dto>(mapper.Map<Entity, Dto>(tempEntity));
        }

        public virtual async Task<BaseResponse<Dto>> Remove(int id)
        {
            var tempEntity = await repository.GetById(id);
            if (tempEntity is null)
            {
                return new BaseResponse<Dto>("Record Not Found");
            }
            await repository.Delete(tempEntity);
            return new BaseResponse<Dto>(mapper.Map<Entity, Dto>(tempEntity));
        }

        public virtual async Task<BaseResponse<Dto>> Update(int id, Dto updateResource)
        {
            var tempEntity = await repository.GetById(id);
            if (tempEntity is null)
            {
                return new BaseResponse<Dto>("Record Not Found");
            }

            var entity = mapper.Map<Dto, Entity>(updateResource, tempEntity);
            await repository.Update(entity);

            var resource = mapper.Map<Entity, Dto>(entity);
            return new BaseResponse<Dto>(resource);
        }
    }
}
