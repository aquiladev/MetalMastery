using System;
using System.Collections.Generic;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;
using MetalMastery.Services.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;

namespace MetalMastery.Services.Tests
{
    [TestFixture]
    public class StateServiceTests
    {
        private MockRepository _mockRepository;
        private IRepository<State> _repository;

        private IStateService _service;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _repository = _mockRepository.DynamicMock<IRepository<State>>();

            _service = new StateService(_repository);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetThingByName_IdIsEmpty_Exception()
        {
            _service.GetThingByName(string.Empty);
        }

        [Test]
        public void GetThingByName_Founded()
        {
            string name = "test";
            var entity = new State() { Name = name};

            using (_mockRepository.Record())
            {
                _repository.Stub(x => x.Find(y => y.Name == string.Empty))
                    .IgnoreArguments()
                    .Return(new List<State>
                                {
                                    entity
                                });
            }

            var result = _service.GetThingByName(name);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetThingByName_NotFound_ReturnNull()
        {
            string name = "test";

            using (_mockRepository.Record())
            {
                _repository.Stub(x => x.Find(y => y.Name == string.Empty))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _service.GetThingByName(name);

            Assert.IsNull(result);
        }
    }
}
