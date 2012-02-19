using System;
using MetalMastery.Core;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services
{
    public interface IMaterialService
    {
        /// <summary>
        /// Get all material with paging
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Material collection</returns>
        IPagedList<Material> GetAllMaterials(int pageIndex, int pageSize);

        /// <summary>
        /// Delete a material
        /// </summary>
        /// <param name="material">Material</param>
        void DeleteMaterial(Material material);

        /// <summary>
        /// Insert a material
        /// </summary>
        /// <param name="material">Material</param>
        void InsertMaterial(Material material);

        /// <summary>
        /// Update a material
        /// </summary>
        /// <param name="material">Material</param>
        void UpdateMaterial(Material material);

        /// <summary>
        /// Get material by identify
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Material</returns>
        Material GetMaterialById(Guid id);
    }
}
