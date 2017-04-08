using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartLeopard.Dal.Framework;

namespace SmartLeopard.Bll
{ 
    public abstract class DataService<TEntity> where TEntity : IEntity
    {
        protected IRepository<TEntity> Repository { get; }

        public DataService(IRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entityToAdd)
        {
            if (entityToAdd.Id > 0)
                return entityToAdd;
            var entityToReturn = Repository.Add(entityToAdd);
            entityToAdd.Created = DateTime.Now;
            entityToAdd.Updated = DateTime.Now;

            await Repository.SaveChangesAsync();
            return entityToReturn;
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await Repository.GetAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await Repository.GetAsync(predicate);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entityToUpdate)
        {
            var entityDb = await Repository.GetAsync(entityToUpdate.Id);
            entityDb.Updated = DateTime.Now;
            await Repository.SaveChangesAsync();
            return entityDb;
        }

        public virtual async Task DeleteAsync(TEntity entityToDelete)
        {
            Repository.Delete(entityToDelete);
            await Repository.SaveChangesAsync();
        }
    }
}
