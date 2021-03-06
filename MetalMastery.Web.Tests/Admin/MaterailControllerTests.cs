﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using MetalMastery.Core;
using MetalMastery.Core.Domain;
using MetalMastery.Services.Interfaces;
using MetalMastery.Web.App_LocalResources;
using MetalMastery.Web.Areas.Admin.Controllers;
using MetalMastery.Web.Areas.Admin.Models;
using NUnit.Framework;
using Rhino.Mocks;

namespace MetalMastery.Web.Tests.Admin
{
    [TestFixture]
    public class MaterialControllerTests
    {
        private IMaterialService _materialService;
        private MockRepository _mockRepository;
        private MaterialController _materialController;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _materialService = _mockRepository.DynamicMock<IMaterialService>();

            _materialController = new MaterialController(_materialService);
            Mapper.CreateMap<Material, MaterialModel>();
            Mapper.CreateMap<MaterialModel, Material>();
        }

        [Test]
        public void Index_ReturnMaterials_CorrectCount()
        {
            IPagedList<Material> materialList = new PagedList<Material>(
                new List<Material>
                    {
                        new Material(),
                        new Material()
                    },
                0, 2);

            using (_mockRepository.Record())
            {
                _materialService.Stub(x => x.GetAll(0, 0)).IgnoreArguments().Return(materialList);
            }

            var result = _materialController.Index();

            Assert.AreEqual(((List<MaterialModel>)result.Model).Count, 2);
        }

        [Test]
        public void Edit_IdIsEmpty_Error()
        {
            var result = _materialController.Edit(Guid.Empty);

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.IdEmptyError);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void Edit_MaterialNotFound_Error()
        {
            var id = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _materialService.Stub(x => x.GetEntityById(id)).Return(null);
            }

            var result = _materialController.Edit(id);

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.MaterialNotFound);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void Edit_FoundedMaterial_CorrectView()
        {
            var id = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _materialService.Stub(x => x.GetEntityById(id)).Return(new Material());
            }

            var result = _materialController.Edit(id);

            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void Delete_GetMaterial_ModelNotNull()
        {
            using (_mockRepository.Record())
            {
                _materialService.Stub(x => x.GetEntityById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new Material());
            }

            var result = _materialController.Delete(Guid.NewGuid());
            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Delete_IdIsEmpty_Exception()
        {
            _materialController.Delete(Guid.Empty);
        }

        [Test]
        public void Delete_MaterialNotFound_Error()
        {
            using (_mockRepository.Record())
            {
                _materialService.Stub(x => x.GetEntityById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _materialController.Delete(Guid.NewGuid());

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.MaterialNotFound);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteConfirmed_IdIsEmpty_Exception()
        {
            _materialController.DeleteConfirmed(Guid.Empty);
        }

        [Test]
        public void DeleteConfirmed_MaterialNotFound_Error()
        {
            using (_mockRepository.Record())
            {
                _materialService.Stub(x => x.GetEntityById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _materialController.DeleteConfirmed(Guid.NewGuid());

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.MaterialNotFound);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void DeleteConfirmed_CorrectDelete_Redirect()
        {
            using (_mockRepository.Record())
            {
                _materialService.Stub(x => x.GetEntityById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new Material());
            }

            var result = (RedirectToRouteResult)_materialController.DeleteConfirmed(Guid.NewGuid());

            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void EditPost_ModelIncorrect()
        {
            _materialController.ModelState.AddModelError("some", "err");

            using (_mockRepository.Record())
            {
                _materialService.Stub(x => x.GetEntityById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new Material());
            }

            var result = _materialController.Edit(new MaterialModel());

            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void EditPost_CorrectEdit_Redirect()
        {
            var result = (RedirectToRouteResult)_materialController.Edit(new MaterialModel());
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void CreatePost_ModelIncorrect()
        {
            _materialController.ModelState.AddModelError("some", "err");

            var result = _materialController.Create(new MaterialModel());

            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void CreatePost_CorrectEdit_Redirect()
        {
            var result = (RedirectToRouteResult)_materialController.Create(new MaterialModel());
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }
    }
}
