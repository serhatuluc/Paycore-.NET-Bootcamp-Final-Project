using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnionArcExample.Application
{
    public interface IHibernateRepository<Entity> where Entity : class
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        Task Save(Entity entity);
        Task Update(Entity entity);
        Task Delete(int id);
        Task<List<Entity>> GetAll();
        Task<Entity> GetById(int id);
        IEnumerable<Entity> Find(Expression<Func<Entity, bool>> expression);
        IEnumerable<Entity> Where(Expression<Func<Entity, bool>> where);

        IQueryable<Entity> Entities { get; }
    }
}
