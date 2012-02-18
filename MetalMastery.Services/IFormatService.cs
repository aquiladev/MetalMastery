using System;
using MetalMastery.Core;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services
{
    public interface IFormatService
    {
        /// <summary>
        /// Get all format with paging
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Format collection</returns>
        IPagedList<Format> GetAllFormats(int pageIndex, int pageSize);

        /// <summary>
        /// Delete a format
        /// </summary>
        /// <param name="format">Format</param>
        void DeleteFormat(Format format);

        /// <summary>
        /// Insert a format
        /// </summary>
        /// <param name="format">Format</param>
        void InsertFormat(Format format);

        /// <summary>
        /// Update a format
        /// </summary>
        /// <param name="format">Format</param>
        void UpdateFormat(Format format);

        /// <summary>
        /// Get format by identify
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Format</returns>
        Format GetFormatById(Guid id);
    }
}
