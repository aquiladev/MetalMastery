using System.Collections.Generic;
using AutoMapper;
using MetalMastery.Core;
using MetalMastery.Core.Domain;
using MetalMastery.Core.Mvc;
using MetalMastery.Services;
using MetalMastery.Web.Areas.Admin.Models;
using MetalMastery.Web.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace MetalMastery.Web.Tests
{
    [TestFixture]
    public class ArticleControllerTests
    {
        private MockRepository _mockRepository;
        private IArticleService _articleService;

        private ArticleController _articleController;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _articleService = _mockRepository.DynamicMock<IArticleService>();

            _articleController = new ArticleController(_articleService);
            Mapper.CreateMap<Article, ArticleModel>();
            Mapper.CreateMap<ArticleModel, Article>();
        }

        [Test]
        public void GetArticles_CorrectCount()
        {
            IPagedList<Article> articleList = new PagedList<Article>(
                new List<Article>
                    {
                        new Article(),
                        new Article()
                    },
                0, 2);

            using (_mockRepository.Record())
            {
                _articleService.Stub(x => x.GetAllArticles(0, 0)).IgnoreArguments().Return(articleList);
            }

            var result = _articleController.GetArticles();
            var data = (List<ArticleModel>) result.Data;

            Assert.AreEqual(((MmJsonResult)result).Success, true);
            Assert.AreEqual(data.Count, 2);
        }
    }
}
