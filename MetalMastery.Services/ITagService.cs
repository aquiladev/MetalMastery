using System;
using MetalMastery.Core;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services
{
    public interface ITagService
    {
        /// <summary>
        /// Get all tag with paging
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Tag collection</returns>
        IPagedList<Tag> GetAllTags(int pageIndex, int pageSize);

        /// <summary>
        /// Delete a tag
        /// </summary>
        /// <param name="tag">Tag</param>
        void DeleteTag(Tag tag);

        /// <summary>
        /// Insert a tag
        /// </summary>
        /// <param name="tag">Tag</param>
        void InsertTag(Tag tag);

        /// <summary>
        /// Update a tag
        /// </summary>
        /// <param name="tag">Tag</param>
        void UpdateTag(Tag tag);

        /// <summary>
        /// Get tag by identify
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Tag</returns>
        Tag GetTagById(Guid id);
    }
}
