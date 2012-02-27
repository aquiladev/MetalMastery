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
    public class AdminFormatControllerTests
    {
        private IFormatService _formatService;
        private MockRepository _mockRepository;
        private FormatController _formatController;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _formatService = _mockRepository.DynamicMock<IFormatService>();

            _formatController = new FormatController(_formatService);
            Mapper.CreateMap<Format, FormatModel>();
            Mapper.CreateMap<FormatModel, Format>();
        }

        [Test]
        public void Index_ReturnFormats_CorrectCount()
        {
            IPagedList<Format> formatList = new PagedList<Format>(
                new List<Format>
                    {
                        new Format(),
                        new Format()
                    },
                0, 2);

            using (_mockRepository.Record())
            {
                _formatService.Stub(x => x.GetAllFormats(0, 0)).IgnoreArguments().Return(formatList);
            }

            var result = _formatController.Index();

            Assert.AreEqual(((List<FormatModel>)result.Model).Count, 2);
        }

        [Test]
        public void Edit_IdIsEmpty_Error()
        {
            var result = _formatController.Edit(Guid.Empty);

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.IdEmptyError);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void Edit_FormatNotFound_Error()
        {
            var id = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _formatService.Stub(x => x.GetFormatById(id)).Return(null);
            }

            var result = _formatController.Edit(id);

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.FormatNotFound);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void Edit_FoundedFormat_CorrectView()
        {
            var id = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _formatService.Stub(x => x.GetFormatById(id)).Return(new Format());
            }

            var result = _formatController.Edit(id);

            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void Delete_GetFormat_ModelNotNull()
        {
            using (_mockRepository.Record())
            {
                _formatService.Stub(x => x.GetFormatById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new Format());
            }

            var result = _formatController.Delete(Guid.NewGuid());
            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Delete_IdIsEmpty_Exception()
        {
            _formatController.Delete(Guid.Empty);
        }

        [Test]
        public void Delete_FormatNotFound_Error()
        {
            using (_mockRepository.Record())
            {
                _formatService.Stub(x => x.GetFormatById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _formatController.Delete(Guid.NewGuid());

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.FormatNotFound);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteConfirmed_IdIsEmpty_Exception()
        {
            _formatController.DeleteConfirmed(Guid.Empty);
        }

        [Test]
        public void DeleteConfirmed_FormatNotFound_Error()
        {
            using (_mockRepository.Record())
            {
                _formatService.Stub(x => x.GetFormatById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _formatController.DeleteConfirmed(Guid.NewGuid());

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.FormatNotFound);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void DeleteConfirmed_CorrectDelete_Redirect()
        {
            using (_mockRepository.Record())
            {
                _formatService.Stub(x => x.GetFormatById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new Format());
            }

            var result = (RedirectToRouteResult)_formatController.DeleteConfirmed(Guid.NewGuid());

            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void EditPost_ModelIncorrect()
        {
            _formatController.ModelState.AddModelError("some", "err");

            using (_mockRepository.Record())
            {
                _formatService.Stub(x => x.GetFormatById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new Format());
            }

            var result = _formatController.Edit(new FormatModel());

            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void EditPost_CorrectEdit_Redirect()
        {
            var result = (RedirectToRouteResult)_formatController.Edit(new FormatModel());
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void CreatePost_ModelIncorrect()
        {
            _formatController.ModelState.AddModelError("some", "err");

            var result = _formatController.Create(new FormatModel());

            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void CreatePost_CorrectEdit_Redirect()
        {
            var result = (RedirectToRouteResult)_formatController.Create(new FormatModel());
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }
    }
}
