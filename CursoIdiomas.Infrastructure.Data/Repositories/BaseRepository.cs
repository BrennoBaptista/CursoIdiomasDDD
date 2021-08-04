using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Repositories;
using CursoIdiomas.Infrastructure.Data.Context;
using CursoIdiomas.Infrastructure.Data.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : EntidadeBase<TKey>
    {
        protected CursoIdiomasContext db = new CursoIdiomasContext();
        private readonly IIdFactory<TKey> _idFactory;

        public BaseRepository(IIdFactory<TKey> idFactory)
        {
            _idFactory = idFactory;
        }

        public async Task CreateAsync(TEntity entity)
        {
            entity.Id = _idFactory.GenereteId();
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
            var entry = db.Set<TEntity>().Find(entity.Id);
            db.Entry(entry).CurrentValues.SetValues(entity);
            db.SaveChanges();
        }

        public async Task DeleteAsync(TKey id)
        {
            db.Set<TEntity>().Remove(await ReadAsync(id));
            db.SaveChanges();
        }
    }
}