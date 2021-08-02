using CursoIdiomas.Application.Interfaces;
using CursoIdiomas.Domain.Entities;
using CursoIdiomas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Application
{
    public class BaseAppService<TEntity, TKey> : IDisposable, IBaseAppService<TEntity, TKey> where TEntity : EntidadeBase<TKey>
    {
        private readonly IBaseService<TEntity, TKey> _baseService;
        public BaseAppService(IBaseService<TEntity, TKey> baseService)
        {
            _baseService = baseService;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _baseService.CreateAsync(entity);
        }

        public async Task<TEntity> ReadAsync(TKey id)
        {
            return await _baseService.ReadAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ReadAllAsync()
        {
            return await _baseService.ReadAllAsync();
        }

        public IEnumerable<TEntity> ReadAll()
        {
            return _baseService.ReadAll();
        }

        public void Update(TEntity entity)
        {
            _baseService.Update(entity);
        }

        public async Task DeleteAsync(TKey id)
        {
            await _baseService.DeleteAsync(id);
        }

        public void Dispose()
        {
            _baseService.Dispose();
        }
    }
}