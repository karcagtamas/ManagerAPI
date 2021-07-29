using ManagerAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ManagerAPI.Services.Common.Repository
{
    /// <summary>
    /// Repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// Get all entity
        /// </summary>
        /// <returns>All existing entity</returns>
        List<TEntity> GetAll();

        /// <summary>
        /// Get all entity.
        /// </summary>
        /// <typeparam name="T">Type of mappable result type</typeparam>
        /// <returns>Mapped entity list to the destination type</returns>
        List<T> GetAll<T>();

        /// <summary>
        /// Get list of entities.
        /// </summary>
        /// <param name="predicate">Filter predicate.</param>
        /// <returns>Filtered list of entities</returns>
        List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Get list of entities.
        /// </summary>
        /// <param name="predicate">Filter predicate.</param>
        /// <typeparam name="T">Type of mappable result type</typeparam>
        /// <returns>Mapped filtered list of entities to destination type</returns>
        List<T> GetList<T>(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Get list of entities.
        /// </summary>
        /// <param name="predicate">Filter predicate.</param>
        /// <param name="count">Max result count.</param>
        /// <returns>Filtered list of entities with max count.</returns>
        List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate, int? count);

        /// <summary>
        /// Get list of entities.
        /// </summary>
        /// <param name="predicate">Filter predicate.</param>
        /// <param name="count">Max result count.</param>
        /// <typeparam name="T">Type of mappable result type</typeparam>
        /// <returns>Mapped filtered list of entities with max count to destination type</returns>
        List<T> GetList<T>(Expression<Func<TEntity, bool>> predicate, int? count);

        /// <summary>
        /// Get list of entities.
        /// </summary>
        /// <param name="predicate">Filter predicate.</param>
        /// <param name="count">Max result count.</param>
        /// <param name="skip">Skipped element number.</param>
        /// <returns>Filtered list of entities with max count and first skip.</returns>
        List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate, int? count, int? skip);

        /// <summary>
        /// Get list of entities.
        /// </summary>
        /// <param name="predicate">Filter predicate.</param>
        /// <param name="count">Max result count.</param>
        /// <param name="skip">Skipped element number.</param>
        /// <typeparam name="T">Type of mappable result type</typeparam>
        /// <returns>Mapped filtered list of entities with max count and first skip to destination type</returns>
        List<T> GetList<T>(Expression<Func<TEntity, bool>> predicate, int? count, int? skip);

        /// <summary>
        /// Get ordered list
        /// </summary>
        /// <param name="orderBy">Ordering by</param>
        /// <param name="direction">Order direction</param>
        /// <returns>Ordered all list</returns>
        List<TEntity> GetOrderedAll(string orderBy, string direction);

        /// <summary>
        /// Get ordered list
        /// </summary>
        /// <param name="orderBy">Order by</param>
        /// <param name="direction">Order direction</param>
        /// <typeparam name="T">Type of mappable result type</typeparam>
        /// <returns>Mapped and ordered list</returns>
        List<T> GetOrderedAll<T>(string orderBy, string direction);

        /// <summary>
        /// Get entity
        /// </summary>
        /// <param name="keys">Identity keys of entity</param>
        /// <returns>Entity with the given keys</returns>
        TEntity Get(params object[] keys);

        /// <summary>
        /// Get entity
        /// </summary>
        /// <param name="keys">Identity keys of entity</param>
        /// <typeparam name="T">Type of mappable result type</typeparam>
        /// <returns>Mapped entity to the destination type</returns>
        T Get<T>(params object[] keys);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Update(TEntity entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="id">Id of entity</param>
        /// <param name="entity">Entity model object</param>
        /// <typeparam name="T">Mappable type</typeparam>
        void Update<T>(int id, T entity);

        /// <summary>
        /// Update multiple entity
        /// </summary>
        /// <param name="entities">Entities</param>
        void UpdateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Update multiple entity
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <typeparam name="T">Mappable type</typeparam>
        void UpdateRange<T>(Dictionary<int, T> entities);

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity">Entity object</param>
        void Add(TEntity entity);

        /// <summary>
        /// Add multiple entity.
        /// </summary>
        /// <param name="entities">Entities</param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Add entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <typeparam name="T">Type of mappable entity</typeparam>
        void Add<T>(T entity);

        /// <summary>
        /// Add multiple entity
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <typeparam name="T">Type of mappable entities</typeparam>
        void AddRange<T>(IEnumerable<T> entities);

        /// <summary>
        /// Remove entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Remove range
        /// </summary>
        /// <param name="entities">Entities</param>
        void RemoveRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Remove by Id
        /// </summary>
        /// <param name="id">Id of entity</param>
        void Remove(int id);

        /// <summary>
        /// Remove range by Id
        /// </summary>
        /// <param name="ids">List of Ids</param>
        void RemoveRange(IEnumerable<int> ids);

        /// <summary>
        /// Save changes
        /// </summary>
        void Complete();
    }
}