using SavingCloud.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SavingCloud
{
    /// <summary>
    /// 数据仓储
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        private static SavingCloudContainer db;
        private readonly DbSet<TEntity> Table;

        public Repository()
        {
            if (db == null)
            {
                db = new SavingCloudContainer();
            }
            Table = db.Set<TEntity>();
        }

        protected virtual void AttachIfNot(TEntity entity)
        {
            if (!Table.Local.Contains(entity))
            {
                Table.Attach(entity);
            }
        }


        public int Count()
        {
            return Table.Count();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.Count(predicate);
        }

        public TEntity Create(TEntity entity)
        {
            return Table.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            Table.Remove(entity);
        }

        public void Delete(TPrimaryKey id)
        {
            var entity = Table.Local.FirstOrDefault(ent => EqualityComparer<TPrimaryKey>.Default.Equals(ent._EntityKey, id));
            if (entity == null)
            {
                entity = Table.Find(id);
                if (entity == null)
                {
                    return;
                }
            }

            Delete(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> objects = Table.Where<TEntity>(predicate).AsEnumerable();
            foreach (TEntity obj in objects)
                Table.Remove(obj);
        }


        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = Table.Local.FirstOrDefault(predicate.Compile());
            if (entity == null)
            {
                return Table.FirstOrDefault(predicate);
            }
            return entity;
        }

        public TEntity Get(TPrimaryKey id)
        {
            return Table.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Table;
        }


        public TEntity Update(TEntity entity)
        {
            AttachIfNot(entity);
            db.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public TEntity Update(TPrimaryKey id, Action<TEntity> updateAction)
        {
            var entity = Get(id);
            if (entity != null)
            {
                updateAction(entity);
            }
            else
            {
                //Core.Logging.Logger.Error($"更新数据id:{id},找不到该数据");
            }
            return entity;
        }


        public List<T> Query<T>(string sql, params object[] sqlParams)
        {
            return db.Database.SqlQuery<T>(sql, sqlParams).ToList();
        }

        public int ExecuteNonquery(string sql, params object[] sqlParams)
        {
            return db.Database.ExecuteSqlCommand(sql, sqlParams);
        }
    }
}
