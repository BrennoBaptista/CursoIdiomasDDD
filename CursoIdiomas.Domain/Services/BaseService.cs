using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Repositories;
using CursoIdiomas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Services
{
    public class BaseService<TEntity, TKey> : IDisposable, IBaseService<TEntity, TKey> where TEntity : EntidadeBase<TKey>
    {
        private readonly IBaseRepository<TEntity, TKey> _repository;
        public BaseService(IBaseRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _repository.CreateAsync(entity);
        }

        public async Task<TEntity> ReadAsync(TKey id)
        {
            return await _repository.ReadAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ReadAllAsync()
        {
            return await _repository.ReadAllAsync();
        }

        public IEnumerable<TEntity> ReadAll()
        {
            return _repository.ReadAll();
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public async Task DeleteAsync(TKey id)
        {
            await _repository.DeleteAsync(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}