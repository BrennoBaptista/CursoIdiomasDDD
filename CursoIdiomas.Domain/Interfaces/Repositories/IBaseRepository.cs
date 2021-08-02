using CursoIdiomas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursoIdiomas.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : EntidadeBase<TKey>
    {
        Task CreateAsync(TEntity entity);
        Task<TEntity> ReadAsync(TKey id);
        IEnumerable<TEntity> ReadAll();
        Task<IEnumerable<TEntity>> ReadAllAsync();
        void Update(TEntity entity);
        Task DeleteAsync(TKey id);
        void Dispose();
    }
}
