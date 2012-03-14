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

            var articles = _articleRepository.Find(x => x.Id == article.Id);
            var articleRep = articles == null
                ? null
                : articles.FirstOrDefault();

            if (articleRep == null)
            {
                throw new InvalidOperationException("Article didn't found");
            }

            articleRep.Text = article.Text;
            articleRep.Title = article.Title;
            articleRep.IsPublished = article.IsPublished;

            _articleRepository.SaveChanges();
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
