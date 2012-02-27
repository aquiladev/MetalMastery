using System;
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
            return new PagedList<Article>(_articleRepository
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
                                                                   OwnerId = a.OwnerId
                                                               })
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
    }
}
