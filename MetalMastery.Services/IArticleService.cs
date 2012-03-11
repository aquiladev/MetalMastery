using System;
using MetalMastery.Core;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services
{
    public interface IArticleService
    {
        /// <summary>
        /// Get all articles with paging
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>User collection</returns>
        IPagedList<Article> GetAllArticles(int pageIndex, int pageSize);

        /// <summary>
        /// Get published articles with paging
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>User collection</returns>
        IPagedList<Article> GetPublishedArticles(int pageIndex, int pageSize); 

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

        /// <summary>
        /// Get article by identify
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Article</returns>
        Article GetArticleById(Guid id);
    }
}
