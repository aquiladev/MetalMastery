using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using MetalMastery.Core;
using MetalMastery.Core.Domain;
using MetalMastery.Services;
using MetalMastery.Web.App_LocalResources;
using MetalMastery.Web.Areas.Admin.Controllers;
using MetalMastery.Web.Areas.Admin.Models;
using NUnit.Framework;
using Rhino.Mocks;

namespace MetalMastery.Web.Tests.Admin
{
    [TestFixture]
    public class AdminArticleControllerTests
    {
        private IArticleService _articleService;
        private IUserService _userService;
        private MockRepository _mockRepository;
        private ArticleController _articleController;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _articleService = _mockRepository.DynamicMock<IArticleService>();
            _userService = _mockRepository.DynamicMock<IUserService>();

            _articleController = new ArticleController(_articleService, _userService);
            Mapper.CreateMap<Article, ArticleModel>();
            Mapper.CreateMap<ArticleModel, Article>();
        }

        [Test]
        public void Index_ReturnArticles_CorrectCount()
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

            var result = _articleController.Index();

            Assert.AreEqual(((List<ArticleModel>)result.Model).Count, 2);
        }

        [Test]
        public void Edit_IdIsEmpty_Error()
        {
            var result = _articleController.Edit(Guid.Empty);

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.IdEmptyError);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void Edit_ArticleNotFound_Error()
        {
            var id = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _articleService.Stub(x => x.GetArticleById(id)).Return(null);
            }

            var result = _articleController.Edit(id);

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.ArticleNotFound);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void Edit_FoundedArticle_CorrectView()
        {
            var id = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _articleService.Stub(x => x.GetArticleById(id)).Return(new Article());
            }

            var result = _articleController.Edit(id);

            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void Delete_GetArticle_ModelNotNull()
        {
            using (_mockRepository.Record())
            {
                _articleService.Stub(x => x.GetArticleById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new Article());
            }

            var result = _articleController.Delete(Guid.NewGuid());
            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Delete_IdIsEmpty_Exception()
        {
            _articleController.Delete(Guid.Empty);
        }

        [Test]
        public void Delete_ArticleNotFound_Error()
        {
            using (_mockRepository.Record())
            {
                _articleService.Stub(x => x.GetArticleById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _articleController.Delete(Guid.NewGuid());

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.ArticleNotFound);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteConfirmed_IdIsEmpty_Exception()
        {
            _articleController.DeleteConfirmed(Guid.Empty);
        }

        [Test]
        public void DeleteConfirmed_ArticleNotFound_Error()
        {
            using (_mockRepository.Record())
            {
                _articleService.Stub(x => x.GetArticleById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _articleController.DeleteConfirmed(Guid.NewGuid());

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.ArticleNotFound);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void DeleteConfirmed_CorrectDelete_Redirect()
        {
            using (_mockRepository.Record())
            {
                _articleService.Stub(x => x.GetArticleById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new Article());
            }

            var result = (RedirectToRouteResult)_articleController.DeleteConfirmed(Guid.NewGuid());

            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void EditPost_ModelIncorrect()
        {
            _articleController.ModelState.AddModelError("some", "err");

            using (_mockRepository.Record())
            {
                _articleService.Stub(x => x.GetArticleById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new Article());
            }

            var result = _articleController.Edit(new ArticleModel());

            Assert.IsNotNull(((ViewResultBase)result).Model);
        }
        
        [Test]
        public void EditPost_CorrectEdit_Redirect()
        {
            var result = (RedirectToRouteResult)_articleController.Edit(new ArticleModel());
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void CreatePost_ModelIncorrect()
        {
            _articleController.ModelState.AddModelError("some", "err");
            
            var result = _articleController.Create(new ArticleModel(), "user");

            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void CreatePost_UserNotFound_Error()
        {
            using (_mockRepository.Record())
            {
                _userService.Stub(x => x.GetUserByEmail("email"))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _articleController.Create(new ArticleModel(), "user");

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.UserNotFound);
            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void CreatePost_CorrectEdit_Redirect()
        {
            var result = (RedirectToRouteResult)_articleController.Create(new ArticleModel(), "user");
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Details_IdIsEmpty_Exception()
        {
            _articleController.Details(Guid.Empty);
        }

        [Test]
        public void Details_Founded()
        {
            using (_mockRepository.Record())
            {
                _articleService.Stub(x => x.GetArticleById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new Article());
            }

            var result = _articleController.Details(Guid.NewGuid());

            Assert.IsNotNull(result.Model);
        }
    }
}
