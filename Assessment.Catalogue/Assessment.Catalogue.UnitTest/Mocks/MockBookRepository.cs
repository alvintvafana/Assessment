using Assessment.Catalogue.Domain;
using Assessment.Catalogue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Catalogue.UnitTest.Mocks
{
    public class MockBookRepository<TEntity> : IRepository<TEntity> where TEntity : Book
    {
        public Dictionary<Guid,TEntity> Table = new Dictionary<Guid,TEntity>();
        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where = null)
        {
            if (where == null)
                return await Task.Run(() => Table.Values.ToList());
            return await Task.Run(() => Table.Values.Where(where.Compile()));
        }

        public async Task<TEntity> GetByIDAsync(object id)
        {
            return await Task.Run(() => Table[(Guid)id]);
        }

        public async Task<TEntity>  GetOneAsync(Expression<Func<TEntity, bool>> where = null)
        {
            return await Task.Run(() => Table.Values.FirstOrDefault(where.Compile()));
        }

        public async Task InsertAsync(TEntity entity)
        {
          await  Task.Run(() => Table.Add(entity.Id,entity));
        }

        public void Update(TEntity entity)
        {
            Table[entity.Id]=entity;
        }
    }
}
