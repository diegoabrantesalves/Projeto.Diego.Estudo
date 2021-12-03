using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Estudo.Core.Interfaces.Repository
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "");
        Task InsertAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(object id);
        void Update(TEntity entityToUpdate);
        Task DeleteAsync(object id);
    }
}
