using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

///CRUD
namespace Api.Entities.Default
{
    public class RepositoryBase
    {
        protected readonly DbContext Context;

        public RepositoryBase(DbContext dbContext)
        {
            Context = dbContext;
        }

        public List<object> SqlQuery(string sqlQueryOrCmd)
        {
            var arrList = new List<object>();
            using (var command = Context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = sqlQueryOrCmd;
                Context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var dynamicObject = new Dictionary<string, object>();
                        for (int i = 0; i < result.FieldCount; i++)
                        {
                            var key = result.GetName(i);
                            var value = result.GetValue(i);
                            dynamicObject.Add(key, value);

                        }
                        arrList.Add(dynamicObject);
                    }
                }
            }
            return arrList;
        }

        public List<TEntity> SqlQuery<TEntity>(string sqlQueryOrCmd)
            where TEntity : class
        {
            var rs = this.SqlQuery(sqlQueryOrCmd);

            return rs as List<TEntity>;
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }

    public class Repository<TEntity> : RepositoryBase
        where TEntity : DefaultEntity
    {
        public Repository(DbContext dbContext) : base(dbContext)
        {
        }

        public bool Insert(TEntity entity)
        {
            var dbSet = Context.Set<TEntity>();
            dbSet.Add(entity);

            var ef = Context.SaveChanges();
            return ef > 0;
        }

        public async Task<bool> InsertAsync(TEntity entity)
        {
            var dbSet = Context.Set<TEntity>();
            await dbSet.AddAsync(entity);

            var ef = await Context.SaveChangesAsync();
            return ef > 0;
        }
        
        public bool Update(TEntity entity)
        {
            var dbSet = Context.Set<TEntity>();
            var store = Context.Entry(entity);

            store.State = EntityState.Modified;

            var ef = Context.SaveChanges();
            return ef > 0;
        }

       public async Task<bool> UpdateAsync(TEntity entity)
        {
            var dbSet = Context.Set<TEntity>();
            var store = Context.Entry(entity);

            store.State = EntityState.Modified;
            
            var ef = await Context.SaveChangesAsync();
            return ef > 0;
        }
        
        public bool Delete(TEntity entity)
        {
            var dbSet = Context.Set<TEntity>();
            var store = Context.Entry(entity);

            store.State = EntityState.Deleted;

            var ef = Context.SaveChanges();
            return ef > 0;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            var dbSet = Context.Set<TEntity>();
            var store = Context.Entry(entity);

            store.State = EntityState.Deleted;
            
            var ef = await Context.SaveChangesAsync();
            return ef > 0;
        }

        public IQueryable<TEntity> Query()
        {
            var query = Context.Set<TEntity>().AsNoTracking();

            return query;
        }
    }
}