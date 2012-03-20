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
        private IRepository<ThingState> _thingStateRepository;

        private IThingService _thingService;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _thingRepository = _mockRepository.DynamicMock<IRepository<Thing>>();
            _thingStateRepository = _mockRepository.DynamicMock<IRepository<ThingState>>();

            _thingService = new ThingService(_thingRepository, _thingStateRepository);
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
        public void GetPublishedThings_CorrectCount()
        {
            Guid completedStateId = Guid.NewGuid();
            Guid saleStateId = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _thingStateRepository.Stub(y => y.Table)
                    .IgnoreArguments()
                    .Return(new List<ThingState>
                                {
                                    new ThingState
                                        {
                                            Name = States.Completed.ToString(),
                                            Id = completedStateId
                                        },
                                    new ThingState
                                        {
                                            Name = States.Sale.ToString(),
                                            Id = saleStateId
                                        }
                                }
                                .AsQueryable());

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
                                             ShowForAll = true,
                                             StateId = saleStateId
                                         },
                                     new Thing
                                         {
                                             ShowForAll = true
                                         },
                                     new Thing()
                                 })
                                .AsQueryable());
            }

            var result = _thingService.GetPublishedThings(0, 100);

            Assert.AreEqual(result.Count(), 2);
        }
    }
}
