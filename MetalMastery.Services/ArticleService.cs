using System;
using System.Collections.Generic;
using System.Linq;
using MetalMastery.Core;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;
using MetalMastery.Services.Interfaces;

namespace MetalMastery.Services
{
    public class ArticleService : BaseEntityService<Article>, IArticleService
    {
        private readonly IRepository<Article> _articleRepository;

        public ArticleService(IRepository<Article> articleRepository)
            : base(articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public override IPagedList<Article> GetAll(int pageIndex, int pageSize)
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

        public override void Update(Article article)
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
            else
            {
                throw new InvalidOperationException("Article didn't found");
            }
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
