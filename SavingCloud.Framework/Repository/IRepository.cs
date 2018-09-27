using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SavingCloud
{
    /// <summary>
    /// 数据仓储接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface IRepository<TEntity, TPrimaryKey> : ITransientDependency where TEntity : EntityBase<TPrimaryKey>
    {
        IQueryable<TEntity> GetAll();

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        TEntity Get(TPrimaryKey id);

        int Count();

        int Count(Expression<Func<TEntity, bool>> predicate);

        List<T> Query<T>(string sql, params object[] sqlParams);

        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Create(TEntity entity);
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Update(TEntity entity);
        /// <summary>
        /// 根据动作更新实体
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateAction"></param>
        /// <returns></returns>
        TEntity Update(TPrimaryKey id, Action<TEntity> updateAction);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);
        /// <summary>
        /// 根据ID删除实体
        /// </summary>
        /// <param name="id"></param>
        void Delete(TPrimaryKey id);
        /// <summary>
        /// 根据条件批量删除实体
        /// </summary>
        /// <param name="predicate"></param>
        void Delete(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 执行无查询的自定义Sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        int ExecuteNonquery(string sql, params object[] sqlParams);
    }

    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : EntityBase<int>
    { }
}
