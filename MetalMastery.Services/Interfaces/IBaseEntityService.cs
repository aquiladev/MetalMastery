using System;
using MetalMastery.Core;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services.Interfaces
{
    public interface IBaseEntityService<T> where T : BaseEntity
    {
        /// <summary>
        /// Get all entities with paging
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Entities collection</returns>
        IPagedList<T> GetAll(int pageIndex, int pageSize);

        /// <summary>
        /// Delete a entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Delete(T entity);

        /// <summary>
        /// Insert a entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Insert(T entity);

        /// <summary>
        /// Update a entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Update(T entity);

        /// <summary>
        /// Get entity by identify
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity</returns>
        T GetEntityById(Guid id);
    }
}
