using System;
using System.Collections.Generic;
using System.Linq;
using Library.Domain.DTO;
using Library.Domain.Interfaces.Repositories;
using Library.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected LibraryDataContext _context = new LibraryDataContext();

        public Response<TEntity> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();

            return new Response<TEntity>
            {
                Success = true,
                Messsage = "",
                Data = entity
            };
        }

        public Response<TEntity> Get(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);

            return new Response<TEntity>
            {
                Success = true,
                Messsage = "",
                Data = entity
            };
        }

        public Response<TEntity> GetAll()
        {
            var entities = _context.Set<TEntity>().AsNoTracking().ToList();
            return new Response<TEntity>
            {
                Success = true,
                Messsage = "",
                Data = entities
            };
        }

        public Response<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();

            return new Response<TEntity>
            {
                Success = true,
                Messsage = "",
                Data = entity
            };
        }

        public Response<TEntity> Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();

            return new Response<TEntity>
            {
                Success = true,
                Messsage = "",
                Data = entity
            };
        }

        public void Dispose() { }
    }
}
