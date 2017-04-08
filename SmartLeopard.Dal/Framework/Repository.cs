using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SmartLeopard.Dal.Framework;

namespace SmartLeopard.Dal
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DatabaseContext Context;
        protected readonly DbSet<TEntity> DbSet; 

        public Repository(DatabaseContext context)
        {
            Context = context;
              DbSet = context.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entityToAdd)
        {
            entityToAdd = DbSet.Add(entityToAdd);
            return entityToAdd;
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual void  Delete(TEntity entityToDelete)
        {
            DbSet.Remove(entityToDelete);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null ? await DbSet.ToArrayAsync() : await DbSet.Where(predicate).ToArrayAsync();
        }  

        public async Task SaveChangesAsync()
        {
           await Context.SaveChangesAsync();
        } 
    }
}
