using Library.Domain.DTO;

namespace Library.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Response<TEntity> Add(TEntity entity);
        Response<TEntity> Get(int id);
        Response<TEntity> GetAll();
        Response<TEntity> Update(TEntity entity);
        Response<TEntity> Remove(TEntity entity);
        void Dispose();
    }
}
