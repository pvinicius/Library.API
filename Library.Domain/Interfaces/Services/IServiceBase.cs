using System;
using System.Collections.Generic;

namespace Library.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity entity);
        TEntity Remove(TEntity entity);
        void Dispose();
    }
}
