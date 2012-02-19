using System;
using System.Collections.Generic;
using System.Linq;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;
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
        public void GetAllMaterials_CorrectCount()
        {
            using (_mockRepository.Record())
            {
                _materialRepository.Stub(x => x.Table)
                    .Return((new List<Material> { new Material() })
                                .AsQueryable());
            }

            var result = _materialService.GetAllMaterials(0, 1);

            Assert.AreEqual(result.Count(), 1);
        }

        [Test]
        public void GetAllMaterials_WithPaging_CorrectCount()
        {
            var materials = new List<Material>();
            for (int i = 0; i < 6; i++)
            {
                materials.Add(new Material());
            }

            using (_mockRepository.Record())
            {
                _materialRepository.Stub(x => x.Table)
                    .Return(materials.AsQueryable());
            }

            var result = _materialService.GetAllMaterials(1, 4);

            Assert.AreEqual(result.Count(), 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteMaterial_MaterialIsNull_Exception()
        {
            _materialService.DeleteMaterial(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateMaterial_MaterialIsNull_Exception()
        {
            _materialService.UpdateMaterial(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertMaterial_MaterialIsNull_Exception()
        {
            _materialService.InsertMaterial(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetMaterialById_IdIsEmpty_Exception()
        {
            _materialService.GetMaterialById(Guid.Empty);
        }

        [Test]
        public void GetMaterialById_Founded()
        {
            var id = Guid.NewGuid();
            var material = new Material { Id = id };

            using (_mockRepository.Record())
            {
                _materialRepository.Stub(x => x.Find(y => y.Id == Guid.Empty))
                    .IgnoreArguments()
                    .Return(new List<Material>
                                {
                                    material
                                });
            }

            var result = _materialService.GetMaterialById(id);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetMaterialById_NotFound_ReturnNull()
        {
            var id = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _materialRepository.Stub(x => x.Find(y => y.Id == Guid.Empty))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _materialService.GetMaterialById(id);

            Assert.IsNull(result);
        }
    }
}
