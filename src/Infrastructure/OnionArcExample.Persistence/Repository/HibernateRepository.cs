using NHibernate;
using NHibernate.Linq;
using OnionArcExample.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnionArcExample.Persistence
{
    public class HibernateRepository<Entity> : IHibernateRepository<Entity> where Entity : class
    {
        private readonly ISession session;
        private ITransaction transaction;

        public HibernateRepository(ISession session)
        {
            this.session = session;
        }

        public  IQueryable<Entity> Entities => session.Query<Entity>();

        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        public async Task Commit()
        {
            await transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await transaction.RollbackAsync();
        }

        public void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
        }

        public async Task Save(Entity entity)
        {
            await session.SaveAsync(entity);
        }

        public async Task Update(Entity entity)
        {
            await session.UpdateAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                await session.DeleteAsync(entity);
            }
        }

        public async Task<List<Entity>> GetAll()
        {
            return session.Query<Entity>().ToList();
        }

        public async Task<List<Entity>> GetAll(Expression<Func<Entity, bool>>? expression = null)
        {
            return expression == null
                ? await session.Query<Entity>().ToListAsync()
                : await session.Query<Entity>().Where(expression).ToListAsync();
        }

        public async Task<Entity> GetById(int id)
        {
            var entity = await session.GetAsync<Entity>(id);
            return entity;
        }

        public IEnumerable<Entity> Where(Expression<Func<Entity, bool>> where)
        {
            return session.Query<Entity>().Where(where).AsQueryable();
        }

        public IEnumerable<Entity> Find(Expression<Func<Entity, bool>> expression)
        {
            return session.Query<Entity>().Where(expression).ToList();
        }

    }
}