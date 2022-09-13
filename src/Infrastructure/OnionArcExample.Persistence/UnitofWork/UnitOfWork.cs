using NHibernate;
using OnionArcExample.Application;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain.Entities;
using OnionArcExample.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcExample.Persistence.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISession session;
        public IAccountRepository _Account;
        public IStoreRepository _Store;
        public IAuthorRepository _Author;

        public UnitOfWork(ISession session, IAccountRepository _Account,IStoreRepository _Store, IAuthorRepository _Author)
        {
            this.session = session;
            this._Account = _Account;
            this._Store = _Store;
            this._Author = _Author;

        }
        public IAccountRepository Account => _Account ??= new AccountRepository(session);

        public IAuthorRepository Author => _Author ??= new AuthorRepository(session);

        public IStoreRepository Store => _Store ??= new StoreRepository(session);

    }
}
