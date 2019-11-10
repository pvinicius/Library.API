using System;
using Library.Domain.DTO;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Services;

namespace Library.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public Response<TEntity> Add(TEntity entity)
        {
            return _repository.Add(entity);
        }

        public Response<TEntity> Get(int id)
        {
            return _repository.Get(id);
        }

        public Response<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public Response<TEntity> Update(TEntity entity)
        {
            return _repository.Update(entity);
        }

        public Response<TEntity> Remove(TEntity entity)
        {
            return _repository.Remove(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
