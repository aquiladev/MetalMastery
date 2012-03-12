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

        private IThingService _thingService;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _thingRepository = _mockRepository.DynamicMock<IRepository<Thing>>();

            _thingService = new ThingService(_thingRepository);
        }
    }
}
