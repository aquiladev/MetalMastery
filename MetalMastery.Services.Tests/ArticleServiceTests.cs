using System;
using System.Collections.Generic;
using System.Linq;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;
using MetalMastery.Services.Interfaces;
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
        public void GetAll_CorrectCount()
        {
            using (_mockRepository.Record())
            {
                _articleRepository.Stub(x => x.Table)
                    .Return((new List<Article> { new Article() })
                                .AsQueryable());
            }

            var result = _articleService.GetAll(0, 10);

            Assert.AreEqual(result.Count(), 1);
        }

        [Test]
        public void GetAll_WithPaging_CorrectCount()
        {
            var entity = new List<Article>();
            for (int i = 0; i < 6; i++)
            {
                entity.Add(new Article());
            }

            using (_mockRepository.Record())
            {
                _articleRepository.Stub(x => x.Table)
                    .Return(entity.AsQueryable());
            }

            var result = _articleService.GetAll(1, 4);

            Assert.AreEqual(result.Count(), 2);
        }

        [Test]
        public void GetAll_OrderByDescending()
        {
            var ar0 = new Article
                          {
                              Id = Guid.NewGuid()
                          };

            var ar1 = new Article
                          {
                              Id = Guid.NewGuid()
                          };

            var ar2 = new Article
                          {
                              Id = Guid.NewGuid()
                          };

            using (_mockRepository.Record())
            {
                _articleRepository.Stub(x => x.Table)
                    .Return(new List<Article> { ar1, ar2, ar0 }.AsQueryable());
            }

            var result = _articleService.GetAll(0, 10);

            Assert.AreEqual(result[0].Id, ar1.Id);
            Assert.AreEqual(result[1].Id, ar2.Id);
            Assert.AreEqual(result[2].Id, ar0.Id);
        }

        [Test]
        public void GetPublishedArticles_CorrectCount()
        {
            using (_mockRepository.Record())
            {
                _articleRepository.Stub(x => x.Table)
                    .Return((new List<Article> { new Article { IsPublished = true }, new Article() })
                                .AsQueryable());
            }

            var result = _articleService.GetPublishedArticles(0, 100);

            Assert.AreEqual(result.Count(), 1);
        }

        [Test]
        public void GetPublishedArticles_WithPaging_CorrectCount()
        {
            var entity = new List<Article>();
            for (int i = 0; i < 9; i++)
            {
                entity.Add(i % 2 == 0 ? new Article { IsPublished = true } : new Article());
            }

            using (_mockRepository.Record())
            {
                _articleRepository.Stub(x => x.Table)
                    .Return(entity.AsQueryable());
            }

            var result = _articleService.GetPublishedArticles(1, 3);

            Assert.AreEqual(result.Count(), 2);
            Assert.AreEqual(result.TotalCount, 5);
            Assert.AreEqual(result.TotalPages, 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Update_ArticleIsNull_Exception()
        {
            _articleService.Update(null);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Update_NotFound_ReturnException()
        {
            using (_mockRepository.Record())
            {
                _articleRepository.Stub(x => x.Find(y => y.Id == Guid.Empty))
                    .IgnoreArguments()
                    .Return(null);
            }

            _articleService.Update(new Article());
        }

        [Test]
        public void Update_ExpectCallSave_Correct()
        {
            using (_mockRepository.Record())
            {
                _articleRepository.Stub(x => x.Find(y => y.Id == Guid.Empty))
                    .IgnoreArguments()
                    .Return(new[] { new Article() });

                _articleRepository.Expect(x => x.SaveChanges());
            }

            _articleService.Update(new Article());

            _articleRepository.VerifyAllExpectations();
        }
    }
}
