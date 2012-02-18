using System;
using System.Collections.Generic;
using System.Linq;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace MetalMastery.Services.Tests
{
    [TestFixture]
    public class ArticleServiceTests
    {
        private MockRepository _mockRepository;
        private IRepository<Article> _articleRepository;

        private IArticleService _articleService;
        
        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _articleRepository = _mockRepository.DynamicMock<IRepository<Article>>();

            _articleService = new ArticleService(_articleRepository);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetArticleById_IdIsEmpty_Exception()
        {
            _articleService.GetArticleById(Guid.Empty);
        }

        [Test]
        public void GetArticleById_Founded()
        {
            var id = Guid.NewGuid();
            var article = new Article() { Id = id };

            using (_mockRepository.Record())
            {
                _articleRepository.Stub(x => x.Find(y => y.Id == Guid.Empty))
                    .IgnoreArguments()
                    .Return(new List<Article>
                                {
                                    article
                                });
            }

            var result = _articleService.GetArticleById(id);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetArticleById_NotFound_ReturnNull()
        {
            var id = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _articleRepository.Stub(x => x.Find(y => y.Id == Guid.Empty))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _articleService.GetArticleById(id);

            Assert.IsNull(result);
        }

        [Test]
        public void GetAllArticles_CorrectCount()
        {
            using (_mockRepository.Record())
            {
                _articleRepository.Stub(x => x.Table)
                    .Return((new List<Article> { new Article() })
                                .AsQueryable());
            }

            var result = _articleService.GetAllArticles(0, 1);

            Assert.AreEqual(result.Count(), 1);
        }

        [Test]
        public void GetAllArticles_WithPaging_CorrectCount()
        {
            var articles = new List<Article>();
            for (int i = 0; i < 6; i++)
            {
                articles.Add(new Article());
            }

            using (_mockRepository.Record())
            {
                _articleRepository.Stub(x => x.Table)
                    .Return(articles.AsQueryable());
            }

            var result = _articleService.GetAllArticles(1, 4);

            Assert.AreEqual(result.Count(), 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteArticle_ArticleIsNull_Exception()
        {
            _articleService.DeleteArticle(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateArticle_ArticleIsNull_Exception()
        {
            _articleService.UpdateArticle(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertArticle_ArticleIsNull_Exception()
        {
            _articleService.InsertArticle(null);
        }
    }
}
