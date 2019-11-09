using System;
using System.Collections.Generic;
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

        public TEntity Add(TEntity entity)
        {
            return _repository.Add(entity);
        }

        public TEntity Get(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity Update(TEntity entity)
        {
            return _repository.Update(entity);
        }

        public TEntity Remove(TEntity entity)
        {
            return _repository.Remove(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
