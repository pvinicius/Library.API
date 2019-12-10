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
            int result = _context.SaveChanges();

            if (result == 1)
                return new Response<TEntity>(success: true, message: "Salvo com sucesso!", data: entity);

            return new Response<TEntity>(success: false, message: "Erro ao salvar", data: entity);
        }

        public Response<TEntity> Get(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            return new Response<TEntity>(success: true, message: "", data: entity);
        }

        public Response<TEntity> GetAll()
        {
            var entities = _context.Set<TEntity>().AsNoTracking().ToList();
            return new Response<TEntity>(success: true, message: "", data: entities);
        }

        public Response<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            int result = _context.SaveChanges();

            if (result == 1)
                return new Response<TEntity>(success: true, message:"Atualizado com sucesso!", data: entity);
            return new Response<TEntity>(success: true, message: "Erro ao atualizar", data: entity);
        }

        public Response<TEntity> Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            int result = _context.SaveChanges();

            if (result == 1)
                return new Response<TEntity>(success: true, message:"Removido com sucesso!", data: entity);
            return new Response<TEntity>(success: true, message: "Erro ao remover", data: entity);
        }

        public void Dispose() { }
    }
}
