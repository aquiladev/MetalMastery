using MetalMastery.Core;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services
{
    public interface IArticleService
    {
        /// <summary>
        /// Get all with paging
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>User collection</returns>
        IPagedList<Article> GetAllArticles(int pageIndex, int pageSize);

        /// <summary>
        /// Delete a article
        /// </summary>
        /// <param name="article">Article</param>
        void DeleteArticle(Article article);

        /// <summary>
        /// Insert a article
        /// </summary>
        /// <param name="article">Article</param>
        void InsertArticle(Article article);

        /// <summary>
        /// Update a article
        /// </summary>
        /// <param name="article">Article</param>
        void UpdateArticle(Article article);
    }
}
