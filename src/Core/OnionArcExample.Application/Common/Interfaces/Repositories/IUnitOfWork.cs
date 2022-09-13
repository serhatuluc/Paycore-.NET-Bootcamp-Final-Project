using OnionArcExample.Domain.Entities;
using System;


namespace OnionArcExample.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
     IAccountRepository Account { get; }
     IAuthorRepository Author { get; }
     IStoreRepository Store { get; }

    }
}
