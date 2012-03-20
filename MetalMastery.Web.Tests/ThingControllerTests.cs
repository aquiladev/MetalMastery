using System;
using System.Collections.Generic;
using AutoMapper;
using MetalMastery.Core;
using MetalMastery.Core.Domain;
using MetalMastery.Core.Mvc;
using MetalMastery.Services.Interfaces;
using MetalMastery.Web.Areas.Admin.Models;
using MetalMastery.Web.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace MetalMastery.Web.Tests
{
    [TestFixture]
    public class ThingControllerTests
    {
        private MockRepository _mockRepository;
        private IThingService _thingService;

        private ThingController _thingController;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _thingService = _mockRepository.DynamicMock<IThingService>();

            _thingController = new ThingController(_thingService);
            Mapper.CreateMap<Thing, ThingModel>();
            Mapper.CreateMap<ThingModel, Thing>();
        }

        [Test]
        public void GetThings_GetOnlyPablishedThings_CorrectCount()
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
                _thingService.Stub(x => x.GetPublishedThings(0, 0))
                    .IgnoreArguments()
                    .Return(thingList);
            }

            var result = _thingController.GetThings();
            var data = (List<ThingModel>)result.Data;

            Assert.AreEqual(((MmJsonResult)result).Success, true);
            Assert.AreEqual(data.Count, 2);
        }

        [Test]
        [Ignore]
        public void Details_IncorrectModelState_Error()
        {
            _thingController.ModelState.AddModelError("error", "msg");

            var result = _thingController.Details(Guid.NewGuid());

            Assert.AreEqual(result, 1);
        }
    }
}
