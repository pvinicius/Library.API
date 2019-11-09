using System.Collections.Generic;

namespace Library.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity entity);
        TEntity Remove(TEntity entity);
        void Dispose();
    }
}
