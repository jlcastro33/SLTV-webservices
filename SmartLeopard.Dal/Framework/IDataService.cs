using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartLeopard.Dal.Framework
{
    public interface IDataService<TEntity> where TEntity : IEntity
    {
        Task<TEntity> AddAsync(TEntity entityToAdd);
        Task DeleteAsync(TEntity entityToDelete);
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<TEntity> UpdateAsync(TEntity entityToUpdate);
    }
}