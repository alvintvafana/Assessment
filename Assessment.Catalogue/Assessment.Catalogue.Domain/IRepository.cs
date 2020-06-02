using Assessment.Catalogue.Domain.Commands;
using Assessment.Catalogue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Assessment.Catalogue.Domain
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIDAsync(object id);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where = null);

        Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> where = null);
        Task InsertAsync(TEntity entity);

        void Update(TEntity entity);
    }
}
