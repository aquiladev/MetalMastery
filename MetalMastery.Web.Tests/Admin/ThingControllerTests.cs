using System;
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
    public class ThingControllerTests
    {
        private IThingService _thingService;
        private ITagService _tagService;
        private IMaterialService _materialService;
        private IFormatService _formatService;
        private IStateService _stateService;
        private IUserService _userService;
        private MockRepository _mockRepository;
        private ThingController _thingController;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _thingService = _mockRepository.DynamicMock<IThingService>();
            _tagService = _mockRepository.DynamicMock<ITagService>();
            _materialService = _mockRepository.DynamicMock<IMaterialService>();
            _formatService = _mockRepository.DynamicMock<IFormatService>();
            _stateService = _mockRepository.DynamicMock<IStateService>();
            _userService = _mockRepository.DynamicMock<IUserService>();

            _thingController = new ThingController(
                _thingService, 
                _tagService,
                _materialService,
                _formatService,
                _stateService,
                _userService);

            Mapper.CreateMap<Thing, ThingModel>();
            Mapper.CreateMap<ThingModel, Thing>();
        }

        [Test]
        public void Index_ReturnThings_CorrectCount()
        {
            IPagedList<Thing> thingList = new PagedList<Thing>(
                new List<Thing>
                    {
                        new Thing(),
                        new Thing()
                    },
                0, 2);

            using (_mockRepository.Record())
            {
                _thingService.Stub(x => x.GetAll(0, 0))
                    .IgnoreArguments()
                    .Return(thingList);
            }

            var result = _thingController.Index();

            Assert.AreEqual(((List<ThingModel>)result.Model).Count, 2);
        }

        [Test]
        public void Edit_IdIsEmpty_Redirect()
        {
            var result = (RedirectToRouteResult)_thingController.Edit(Guid.Empty);

            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void Edit_ThingNotFound_Redirect()
        {
            var id = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _thingService.Stub(x => x.GetEntityById(id)).Return(null);
            }

            var result = (RedirectToRouteResult)_thingController.Edit(id);
            
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void Edit_FoundedThing_CorrectView()
        {
            var id = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _thingService.Stub(x => x.GetEntityById(id)).Return(new Thing());
            }

            var result = _thingController.Edit(id);

            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void Edit_IdIsEmpty_ViewBagCorrect()
        {
            var id = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _thingService.Stub(x => x.GetEntityById(id)).Return(new Thing());

                _tagService.Stub(x => x.GetAll())
                    .IgnoreArguments()
                    .Return(
                        new List<Tag>
                            {
                                new Tag()
                            });

                _materialService.Stub(x => x.GetAll())
                    .IgnoreArguments()
                    .Return(
                        new List<Material>
                            {
                                new Material()
                            });

                _formatService.Stub(x => x.GetAll())
                    .IgnoreArguments()
                    .Return(
                        new List<Format>
                            {
                                new Format()
                            });

                _stateService.Stub(x => x.GetAll())
                    .IgnoreArguments()
                    .Return(
                        new List<State>
                            {
                                new State()
                            });
            }

            var result = (ViewResultBase)_thingController.Edit(id);

            Assert.IsNotNull(result.ViewBag.Tags);
            Assert.IsNotNull(result.ViewBag.Materials);
            Assert.IsNotNull(result.ViewBag.Formats);
            Assert.IsNotNull(result.ViewBag.States);
        }

        [Test]
        public void EditPost_ModelIncorrect_ViewBagCorrect()
        {
            _thingController.ModelState.AddModelError("some", "err");

            using (_mockRepository.Record())
            {
                _thingService.Stub(x => x.GetEntityById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new Thing());

                _tagService.Stub(x => x.GetAll())
                    .IgnoreArguments()
                    .Return(
                        new List<Tag>
                            {
                                new Tag()
                            });

                _materialService.Stub(x => x.GetAll())
                    .IgnoreArguments()
                    .Return(
                        new List<Material>
                            {
                                new Material()
                            });

                _formatService.Stub(x => x.GetAll())
                    .IgnoreArguments()
                    .Return(
                        new List<Format>
                            {
                                new Format()
                            });

                _stateService.Stub(x => x.GetAll())
                    .IgnoreArguments()
                    .Return(
                        new List<State>
                            {
                                new State()
                            });
            }

            var result = (ViewResultBase)_thingController.Edit(new ThingModel());

            Assert.IsNotNull(result.ViewBag.Tags);
            Assert.IsNotNull(result.ViewBag.Materials);
            Assert.IsNotNull(result.ViewBag.Formats);
            Assert.IsNotNull(result.ViewBag.States);
        }

        [Test]
        public void EditPost_ModelIncorrect()
        {
            _thingController.ModelState.AddModelError("some", "err");

            using (_mockRepository.Record())
            {
                _thingService.Stub(x => x.GetEntityById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new Thing());
            }

            var result = _thingController.Edit(new ThingModel());

            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void EditPost_CorrectEdit_Redirect()
        {
            var result = (RedirectToRouteResult)_thingController.Edit(new ThingModel());
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void Delete_GetThing_ModelNotNull()
        {
            using (_mockRepository.Record())
            {
                _thingService.Stub(x => x.GetEntityById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new Thing());
            }

            var result = _thingController.Delete(Guid.NewGuid());
            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Delete_IdIsEmpty_Exception()
        {
            _thingController.Delete(Guid.Empty);
        }

        [Test]
        public void Delete_ThingNotFound_Error()
        {
            using (_mockRepository.Record())
            {
                _thingService.Stub(x => x.GetEntityById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _thingController.Delete(Guid.NewGuid());

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.ThingNotFound);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteConfirmed_IdIsEmpty_Exception()
        {
            _thingController.DeleteConfirmed(Guid.Empty);
        }

        [Test]
        public void DeleteConfirmed_ThingNotFound_Error()
        {
            using (_mockRepository.Record())
            {
                _thingService.Stub(x => x.GetEntityById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _thingController.DeleteConfirmed(Guid.NewGuid());

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.ThingNotFound);
            Assert.IsNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void DeleteConfirmed_CorrectDelete_Redirect()
        {
            using (_mockRepository.Record())
            {
                _thingService.Stub(x => x.GetEntityById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new Thing());
            }

            var result = (RedirectToRouteResult)_thingController.DeleteConfirmed(Guid.NewGuid());

            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void Create_ViewBagCorrect()
        {
            using (_mockRepository.Record())
            {
                _tagService.Stub(x => x.GetAll())
                    .IgnoreArguments()
                    .Return(
                        new List<Tag>
                            {
                                new Tag()
                            });

                _materialService.Stub(x => x.GetAll())
                    .IgnoreArguments()
                    .Return(
                        new List<Material>
                            {
                                new Material()
                            });

                _formatService.Stub(x => x.GetAll())
                    .IgnoreArguments()
                    .Return(
                        new List<Format>
                            {
                                new Format()
                            });

                _stateService.Stub(x => x.GetAll())
                    .IgnoreArguments()
                    .Return(
                        new List<State>
                            {
                                new State()
                            });
            }

            var result = (ViewResultBase)_thingController.Create();

            Assert.IsNotNull(result.ViewBag.Tags);
            Assert.IsNotNull(result.ViewBag.Materials);
            Assert.IsNotNull(result.ViewBag.Formats);
            Assert.IsNotNull(result.ViewBag.States);
        }

        [Test]
        public void CreatePost_ModelIncorrect()
        {
            _thingController.ModelState.AddModelError("some", "err");

            var result = _thingController.Create(new ThingModel());

            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        public void CreatePost_ModelIncorrect_ViewBagCorrect()
        {
            _thingController.ModelState.AddModelError("some", "err");

            using (_mockRepository.Record())
            {
                _tagService.Stub(x => x.GetAll())
                    .IgnoreArguments()
                    .Return(
                        new List<Tag>
                            {
                                new Tag()
                            });

                _materialService.Stub(x => x.GetAll())
                    .IgnoreArguments()
                    .Return(
                        new List<Material>
                            {
                                new Material()
                            });

                _formatService.Stub(x => x.GetAll())
                    .IgnoreArguments()
                    .Return(
                        new List<Format>
                            {
                                new Format()
                            });

                _stateService.Stub(x=> x.GetAll())
                    .IgnoreArguments()
                    .Return(
                        new List<State>
                            {
                                new State()
                            });
            }

            var result = (ViewResultBase)_thingController.Create(new ThingModel());

            Assert.IsNotNull(result.ViewBag.Tags);
            Assert.IsNotNull(result.ViewBag.Materials);
            Assert.IsNotNull(result.ViewBag.Formats);
            Assert.IsNotNull(result.ViewBag.States);
        }

        [Test]
        public void CreatePost_CorrectEdit_Redirect()
        {
            using (_mockRepository.Record())
            {
                _stateService.Stub(x => x.GetStateByName(string.Empty))
                    .IgnoreArguments()
                    .Return(new State());
            }

            var result = (RedirectToRouteResult)_thingController.Create(new ThingModel());
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        [Test]
        public void CreatePost_StateNotFound_ReturnError()
        {
            using (_mockRepository.Record())
            {
                _stateService.Stub(x => x.GetStateByName(string.Empty))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _thingController.Create(new ThingModel());

            Assert.AreEqual(((ViewResultBase)result).ViewBag.Error, MmResources.StateNotFound);
            Assert.IsNotNull(((ViewResultBase)result).Model);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Details_IdIsEmpty_Exception()
        {
            _thingController.Details(Guid.Empty);
        }

        [Test]
        public void Details_Founded()
        {
            using (_mockRepository.Record())
            {
                _thingService.Stub(x => x.GetEntityById(Guid.NewGuid()))
                    .IgnoreArguments()
                    .Return(new Thing());
            }

            var result = _thingController.Details(Guid.NewGuid());

            Assert.IsNotNull(result.Model);
        }
    }
}
