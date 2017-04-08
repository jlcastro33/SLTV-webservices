using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartLeopard.Dal.Framework
{
    public interface IRepository<TEntity> where TEntity :  IEntity 
    {
        TEntity Add(TEntity entityToAdd);
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null); 
        void Delete(TEntity entityToDelete);

        Task SaveChangesAsync();
    }
}
