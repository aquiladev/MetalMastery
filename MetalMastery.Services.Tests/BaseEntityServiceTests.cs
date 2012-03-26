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
    public class BaseEntityServiceTests
    {
        private MockRepository _mockRepository;
        private IRepository<BaseEntity> _repository;

        private IBaseEntityService<BaseEntity> _service;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _repository = _mockRepository.DynamicMock<IRepository<BaseEntity>>();

            _service = new BaseEntityService<BaseEntity>(_repository);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetEntityById_IdIsEmpty_Exception()
        {
            _service.GetEntityById(Guid.Empty);
        }

        [Test]
        public void GetEntityById_Founded()
        {
            var id = Guid.NewGuid();
            var entity = new BaseEntity() { Id = id };

            using (_mockRepository.Record())
            {
                _repository.Stub(x => x.Find(y => y.Id == Guid.Empty))
                    .IgnoreArguments()
                    .Return(new List<BaseEntity>
                                {
                                    entity
                                });
            }

            var result = _service.GetEntityById(id);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetEntityById_NotFound_ReturnNull()
        {
            var id = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _repository.Stub(x => x.Find(y => y.Id == Guid.Empty))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _service.GetEntityById(id);

            Assert.IsNull(result);
        }

        [Test]
        public void GetAll_CorrectCount()
        {
            using (_mockRepository.Record())
            {
                _repository.Stub(x => x.Table)
                    .Return((new List<BaseEntity> { new BaseEntity() })
                                .AsQueryable());
            }

            var result = _service.GetAll(0, 10);

            Assert.AreEqual(result.Count(), 1);
        }

        [Test]
        public void GetAll_WithPaging_CorrectCount()
        {
            var entity = new List<BaseEntity>();
            for (int i = 0; i < 6; i++)
            {
                entity.Add(new BaseEntity());
            }

            using (_mockRepository.Record())
            {
                _repository.Stub(x => x.Table)
                    .Return(entity.AsQueryable());
            }

            var result = _service.GetAll(1, 4);

            Assert.AreEqual(result.Count(), 2);
        }

        [Test]
        public void GetAll_OrderByDescending()
        {
            var ar0 = new BaseEntity()
                          {
                              Id = Guid.NewGuid()
                          };

            var ar1 = new BaseEntity()
                          {
                              Id = Guid.NewGuid()
                          };

            var ar2 = new BaseEntity()
                          {
                              Id = Guid.NewGuid()
                          };

            using (_mockRepository.Record())
            {
                _repository.Stub(x => x.Table)
                    .Return(new List<BaseEntity> { ar1, ar2, ar0 }.AsQueryable());
            }

            var result = _service.GetAll(0, 10);

            Assert.AreEqual(result[0].Id, ar1.Id);
            Assert.AreEqual(result[1].Id, ar2.Id);
            Assert.AreEqual(result[2].Id, ar0.Id);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Delete_EntityIsNull_Exception()
        {
            _service.Delete(null);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Update_NotFound_ReturnException()
        {
            using (_mockRepository.Record())
            {
                _repository.Stub(x => x.Find(y => y.Id == Guid.Empty))
                    .IgnoreArguments()
                    .Return(null);
            }

            _service.Update(new BaseEntity());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Insert_EntityIsNull_Exception()
        {
            _service.Delete(null);
        }
    }
}
