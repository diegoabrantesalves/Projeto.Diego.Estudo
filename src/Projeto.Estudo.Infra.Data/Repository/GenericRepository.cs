using ClearSale.Estudo.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Projeto.Estudo.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClearSale.Estudo.Infra.Data.EntityFramework.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal ApiContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(ApiContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<TEntity?> GetByIdAsync(long id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
          => await dbSet.FirstOrDefaultAsync(predicate);

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            var retorno = await dbSet.AddAsync(entity);
           return retorno.Entity;
        }

        public virtual async Task<TEntity?> DeleteAsync(long id)
        {
            TEntity? entityToDelete = await dbSet.FindAsync(id);
            if (entityToDelete != null)
            {
                dbSet.Remove(entityToDelete);
                await context.SaveChangesAsync();
            }

            return entityToDelete;
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Update(entityToUpdate);            
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
