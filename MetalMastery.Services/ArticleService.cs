using System;
using System.Collections.Generic;
using System.Linq;
using MetalMastery.Core;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IRepository<Article> _articleRepository;

        public ArticleService(IRepository<Article> articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public IPagedList<Article> GetAllArticles(int pageIndex, int pageSize)
        {
            return new PagedList<Article>(
                GetOrderedArcicles()
                    .ToList(),
                pageIndex,
                pageSize);
        }

        public IPagedList<Article> GetPublishedArticles(int pageIndex, int pageSize)
        {
            return new PagedList<Article>(
                GetOrderedArcicles()
                    .Where(x => x.IsPublished)
                    .ToList(),
                pageIndex,
                pageSize);
        }

        public void DeleteArticle(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException("article");
            }

            _articleRepository.Delete(article);
            _articleRepository.SaveChanges();
        }

        public void InsertArticle(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException("article");
            }

            _articleRepository.Insert(article);
            _articleRepository.SaveChanges();
        }

        public void UpdateArticle(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException("article");
            }

            var users = _articleRepository.Find(x => x.Id == article.Id);
            var userRep = users == null
                ? null
                : users.FirstOrDefault();

            if (userRep != null)
            {
                userRep.Text = article.Text;
                userRep.Title = article.Title;
                userRep.IsPublished = article.IsPublished;

                _articleRepository.SaveChanges();
            }
        }

        public Article GetArticleById(Guid id)
        {
            if (id.Equals(default(Guid)))
            {
                throw new ArgumentNullException("id");
            }

            var user = _articleRepository.Find(u => u.Id == id);
            return user == null
                ? null
                : user.FirstOrDefault();
        }

        #region private methods
        private IEnumerable<Article> GetOrderedArcicles()
        {
            return _articleRepository
                .Table
                .OrderByDescending(a => a.CreateDate)
                .ToList()
                .Select(a => new Article
                                 {
                                     Id = a.Id,
                                     CreateDate = a.CreateDate,
                                     Text = a.Text.GetPreviewText(),
                                     Title = a.Title,
                                     Owner = a.Owner,
                                     IsPublished = a.IsPublished,
                                     OwnerId = a.OwnerId
                                 });
        }

        #endregion
    }
}
