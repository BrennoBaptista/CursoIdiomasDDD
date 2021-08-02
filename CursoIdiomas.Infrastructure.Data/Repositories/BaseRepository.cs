using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Repositories;
using CursoIdiomas.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity, TKey> : IDisposable, IBaseRepository<TEntity, TKey> where TEntity : EntidadeBase<TKey>
    {
        protected CursoIdiomasContext db = new CursoIdiomasContext();

        public async Task CreateAsync(TEntity entity)
        {
            await db.Set<TEntity>().AddAsync(entity);
            db.SaveChanges();
        }

        public async Task<TEntity> ReadAsync(TKey id)
        {
            return await db.Set<TEntity>().FindAsync(id);
        }

        public IEnumerable<TEntity> ReadAll()
        {
            return db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> ReadAllAsync()
        {
            return await db.Set<TEntity>().ToListAsync();
        }

        public void Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            //db.Set<TEntity>().Update(entity);
            db.SaveChanges();
        }

        public async Task DeleteAsync(TKey id)
        {
            db.Set<TEntity>().Remove(await ReadAsync(id));
            db.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}