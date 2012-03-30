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
    public class MaterialServiceTests
    {
        private MockRepository _mockRepository;
        private IRepository<Material> _materialRepository;

        private IMaterialService _materialService;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _materialRepository = _mockRepository.DynamicMock<IRepository<Material>>();

            _materialService = new MaterialService(_materialRepository);
        }
        
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateMaterial_MaterialIsNull_Exception()
        {
            _materialService.Update(null);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Update_NotFound_ReturnException()
        {
            using (_mockRepository.Record())
            {
                _materialRepository.Stub(x => x.Find(y => y.Id == Guid.Empty))
                    .IgnoreArguments()
                    .Return(null);
            }

            _materialService.Update(new Material());
        }

        [Test]
        public void Update_ExpectCallSave()
        {
            using (_mockRepository.Record())
            {
                _materialRepository.Stub(x => x.Find(y => y.Id == Guid.Empty))
                    .IgnoreArguments()
                    .Return(new[] {new Material()});

                _materialRepository.Expect(x => x.SaveChanges());
            }

            _materialService.Update(new Material());

            _materialRepository.VerifyAllExpectations();
        }

        [Test]
        public void GetAll_CountCorrect()
        {
            using (_mockRepository.Record())
            {
                _materialRepository.Stub(x => x.Table)
                    .IgnoreArguments()
                    .Return(new List<Material>
                                {
                                    new Material()
                                }
                                .AsQueryable());
            }

            var result = _materialService.GetAll();
            Assert.AreEqual(result.Count, 1);
        }

        [Test]
        public void GetAll_OrderingCorrect()
        {
            using (_mockRepository.Record())
            {
                _materialRepository.Stub(x => x.Table)
                    .IgnoreArguments()
                    .Return(new List<Material>
                                {
                                    new Material { Name = "re" },
                                    new Material { Name = "ds" },
                                    new Material { Name = "ss" }
                                }
                                .AsQueryable());
            }

            var result = _materialService.GetAll();
            Assert.AreEqual(result[0].Name, "ds");
            Assert.AreEqual(result[1].Name, "re");
            Assert.AreEqual(result[2].Name, "ss");
        }
    }
}
