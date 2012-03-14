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
    public class ThingServiceTests
    {
        private MockRepository _mockRepository;
        private IRepository<Thing> _thingRepository;

        private IStateService _stateService;
        private IThingService _thingService;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _thingRepository = _mockRepository.DynamicMock<IRepository<Thing>>();
            _stateService = _mockRepository.DynamicMock<IStateService>();

            _thingService = new ThingService(_thingRepository, _stateService);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Update_ThingIsNull_Exception()
        {
            _thingService.Update(null);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Update_ThingNotFound_Exceptin()
        {
            using (_mockRepository.Record())
            {
                _thingRepository.Stub(x => x.Find(y => y.Id == Guid.Empty))
                    .IgnoreArguments()
                    .Return(null);
            }

            _thingService.Update(new Thing());
        }

        [Test]
        public void GetPublishedCompletedThings_CorrectCount()
        {
            Guid completedStateId = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _stateService.Stub(y => y.GetStateByName(string.Empty))
                    .IgnoreArguments()
                    .Return(new State { Id = completedStateId });

                _thingRepository.Stub(x => x.Table)
                    .Return((new List<Thing>
                                 {
                                     new Thing
                                         {
                                             ShowForAll = true,
                                             StateId = completedStateId
                                         },
                                     new Thing
                                         {
                                             StateId = completedStateId
                                         },
                                     new Thing
                                         {
                                             ShowForAll = true
                                         },
                                     new Thing()
                                 })
                                .AsQueryable());
            }

            var result = _thingService.GetPublishedCompletedThings(0, 100);

            Assert.AreEqual(result.Count(), 1);
        }
    }
}
