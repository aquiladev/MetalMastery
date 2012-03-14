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
        public void GetStateByName_IdIsEmpty_Exception()
        {
            _service.GetStateByName(string.Empty);
        }

        [Test]
        public void GetStateByName_Founded()
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

            var result = _service.GetStateByName(name);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetStateByName_NotFound_ReturnNull()
        {
            string name = "test";

            using (_mockRepository.Record())
            {
                _repository.Stub(x => x.Find(y => y.Name == string.Empty))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _service.GetStateByName(name);

            Assert.IsNull(result);
        }

        [Test]
        public void GetAll_CountCorrect()
        {
            using (_mockRepository.Record())
            {
                _repository.Stub(x => x.Table)
                    .IgnoreArguments()
                    .Return(new List<State>
                                {
                                    new State()
                                }
                                .AsQueryable());
            }

            var result = _service.GetAll();
            Assert.AreEqual(result.Count, 1);
        }

        [Test]
        public void GetAll_OrderingCorrect()
        {
            using (_mockRepository.Record())
            {
                _repository.Stub(x => x.Table)
                    .IgnoreArguments()
                    .Return(new List<State>
                                {
                                    new State { Name = "re" },
                                    new State { Name = "ds" },
                                    new State { Name = "ss" }
                                }
                                .AsQueryable());
            }

            var result = _service.GetAll();
            Assert.AreEqual(result[0].Name, "ds");
            Assert.AreEqual(result[1].Name, "re");
            Assert.AreEqual(result[2].Name, "ss");
        }
    }
}
