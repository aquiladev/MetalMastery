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
    public class AdminTagControllerTests
    {
        private ITagService _tagService;
        private MockRepository _mockRepository;
        private TagController _tagController;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _tagService = _mockRepository.DynamicMock<ITagService>();

            _tagController = new TagController(_tagService);
            Mapper.CreateMap<Tag, TagModel>();
            Mapper.CreateMap<TagModel, Tag>();
        }

        [Test]
        public void Index_ReturnTags_CorrectCount()
        {
            IPagedList<Tag> tagList = new PagedList<Tag>(
                new List<Tag>
                    {
                        new Tag(),
                        new Tag()
                    },
                0, 2);

            using (_mockRepository.Record())
            {
                _tagService.Stub(x => x.GetAllTags(0, 0)).IgnoreArguments().Return(tagList);
            }

            var result = _tagController.Index();

            Assert.AreEqual(((List<TagModel>)result.Model).Count, 2);
        }

        [Test]
        public void Edit_IdIsEmpty_Error()
        {
            var result = _tagController.Edit(Guid.Empty);

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.IdEmptyError);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void Edit_TagNotFound_Error()
        {
            var id = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _tagService.Stub(x => x.GetTagById(id)).Return(null);
            }

            var result = _tagController.Edit(id);

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.TagNotFound);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void Edit_FoundedTag_CorrectView()
        {
            var id = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _tagService.Stub(x => x.GetTagById(id)).Return(new Tag());
            }

            var result = _tagController.Edit(id);

            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void Delete_GetTag_ModelNotNull()
        {
            using (_mockRepository.Record())
            {
                _tagService.Stub(x => x.GetTagById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new Tag());
            }

            var result = _tagController.Delete(Guid.NewGuid());
            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Delete_IdIsEmpty_Exception()
        {
            _tagController.Delete(Guid.Empty);
        }

        [Test]
        public void Delete_TagNotFound_Error()
        {
            using (_mockRepository.Record())
            {
                _tagService.Stub(x => x.GetTagById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _tagController.Delete(Guid.NewGuid());

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.TagNotFound);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteConfirmed_IdIsEmpty_Exception()
        {
            _tagController.DeleteConfirmed(Guid.Empty);
        }

        [Test]
        public void DeleteConfirmed_TagNotFound_Error()
        {
            using (_mockRepository.Record())
            {
                _tagService.Stub(x => x.GetTagById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _tagController.DeleteConfirmed(Guid.NewGuid());

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.TagNotFound);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void DeleteConfirmed_CorrectDelete_Redirect()
        {
            using (_mockRepository.Record())
            {
                _tagService.Stub(x => x.GetTagById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new Tag());
            }

            var result = (RedirectToRouteResult)_tagController.DeleteConfirmed(Guid.NewGuid());

            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void EditPost_ModelIncorrect()
        {
            _tagController.ModelState.AddModelError("some", "err");

            using (_mockRepository.Record())
            {
                _tagService.Stub(x => x.GetTagById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new Tag());
            }

            var result = _tagController.Edit(new TagModel());

            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void EditPost_CorrectEdit_Redirect()
        {
            var result = (RedirectToRouteResult)_tagController.Edit(new TagModel());
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void CreatePost_ModelIncorrect()
        {
            _tagController.ModelState.AddModelError("some", "err");

            var result = _tagController.Create(new TagModel());

            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void CreatePost_CorrectEdit_Redirect()
        {
            var result = (RedirectToRouteResult)_tagController.Create(new TagModel());
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }
    }
}
