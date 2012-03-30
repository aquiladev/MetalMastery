using System;
using System.Collections.Generic;
using System.Linq;

namespace MetalMastery.Core
{
    /// <summary>
    /// Paged list
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
            : this(source.ToList(), pageIndex, pageSize, source.Count()) { }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        public PagedList(IList<T> source, int pageIndex, int pageSize)
            : this(source, pageIndex, pageSize, source.Count) { }

        private PagedList(IList<T> source, int pageIndex, int pageSize, int totalCount)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalCount = totalCount;
            TotalPages = totalCount / pageSize;
            
            if (totalCount % pageSize > 0)
                TotalPages++;

            if (pageIndex < 0 || (pageIndex >= TotalPages && source.Count > 0))
                throw new ArgumentOutOfRangeException("pageIndex");

            AddRange(source.Skip(pageIndex * pageSize).Take(pageSize));
        }

        public int PageIndex { get; private set; } 
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }
        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }
    }
}
