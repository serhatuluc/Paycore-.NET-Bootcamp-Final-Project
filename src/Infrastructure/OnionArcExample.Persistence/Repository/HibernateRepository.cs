using NHibernate;
using NHibernate.Linq;
using OnionArcExample.Application;
using OnionArcExample.Domain.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnionArcExample.Persistence
{
    public class HibernateRepository<Entity> : IRepository<Entity> where Entity : BaseEntity
    {
        private readonly ISession session;
        private ITransaction transaction;

        public HibernateRepository(ISession session)
        {
            this.session = session;
        }

        public async Task Create(Entity entity)
        {
            try
            {
                transaction = session.BeginTransaction();
                await session.SaveAsync(entity);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.Error(ex, "Vehicle Insert Error");
            }
            finally
            {
                session.Dispose();
            };
        }

        public async Task Delete(Entity entity)
        {
            try
            {
                transaction = session.BeginTransaction();
                await session.DeleteAsync(entity);
                transaction.Commit();
            }
            catch (Exception ex)
            {

                Log.Error(ex, "Vehicle Delete Error");
            }
            finally
            {
                session.Dispose();
            };
        }

        public async Task<IEnumerable<Entity>> GetAll(Expression<Func<Entity, bool>> expression = null)
        {
            var listOfcontainers = await session.Query<Entity>().ToListAsync();
            return listOfcontainers;
        }

        public async Task<Entity> GetById(int id)
        {
            return await session.Query<Entity>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Update(Entity entity)
        {
            try
            {
                transaction = session.BeginTransaction();
                await session.UpdateAsync(entity);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Log.Error(ex, "Vehicle Update Error");
            }
            finally
            {
                session.Dispose();
            }
        }
    }
}