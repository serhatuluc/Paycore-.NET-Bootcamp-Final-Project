using AutoMapper;
using NHibernate;
using OnionArcExample.Application;
using OnionArcExample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnionArcExample.Persistence
{
    public abstract class BaseService<Dto, Entity> : IBaseService<Dto, Entity> where Entity : class
    {
        protected readonly ISession session;
        protected readonly IMapper mapper;
        protected readonly IHibernateRepository<Entity> hibernateRepository;


        public BaseService(ISession session, IMapper mapper) : base()
        {
            this.session = session;
            this.mapper = mapper;

            hibernateRepository = new HibernateRepository<Entity>(session);
        }


        public virtual BaseResponse<IEnumerable<Dto>> GetAll()
        {
            var tempEntity = hibernateRepository.Entities.ToList();
            var result = mapper.Map<IEnumerable<Entity>, IEnumerable<Dto>>(tempEntity);
            return new BaseResponse<IEnumerable<Dto>>(result);
        }

        public virtual async Task<BaseResponse<Dto>> GetById(int id)
        {
            var tempEntity = await hibernateRepository.GetById(id);
            var result = mapper.Map<Entity, Dto>(tempEntity);
            return new BaseResponse<Dto>(result);
        }

        public virtual async Task<BaseResponse<Dto>> Insert(Dto insertResource)
        {
            try
            {
                var tempEntity = mapper.Map<Dto, Entity>(insertResource);

                hibernateRepository.BeginTransaction();
                await hibernateRepository.Save(tempEntity);
                await hibernateRepository.Commit();

                hibernateRepository.CloseTransaction();
                return new BaseResponse<Dto>(mapper.Map<Entity, Dto>(tempEntity));
            }
            catch (Exception ex)
            {
                await hibernateRepository .Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<Dto>(ex.Message);
            }

        }

        public virtual async Task<BaseResponse<Dto>> Remove(int id)
        {
            try
            {
                var tempEntity = await hibernateRepository.GetById(id);
                if (tempEntity is null)
                {
                    return new BaseResponse<Dto>("Record Not Found");
                }

                hibernateRepository.BeginTransaction();
                await hibernateRepository .Delete(id);
                await hibernateRepository .Commit();
                hibernateRepository.CloseTransaction();

                return new BaseResponse<Dto>(mapper.Map<Entity, Dto>(tempEntity));
            }
            catch (Exception ex)
            {
                await hibernateRepository.Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<Dto>(ex.Message);
            }
        }

        public virtual async Task<BaseResponse<Dto>> Update(int id, Dto updateResource)
        {
            try
            {
                var tempEntity = await hibernateRepository .GetById(id);
                if (tempEntity is null)
                {
                    return new BaseResponse<Dto>("Record Not Found");
                }


                var entity = mapper.Map<Dto,Entity>(updateResource, tempEntity);

                hibernateRepository.BeginTransaction();
                await hibernateRepository.Update(entity);
                await hibernateRepository .Commit();
                hibernateRepository.CloseTransaction();

                var resource = mapper.Map<Entity, Dto>(entity);
                return new BaseResponse<Dto>(resource);
            }
            catch (Exception ex)
            {
                await hibernateRepository .Rollback();
                hibernateRepository.CloseTransaction();
                return new BaseResponse<Dto>(ex.Message);
            }
        }




    }
}
