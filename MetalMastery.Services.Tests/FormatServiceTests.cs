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
    public class FormatServiceTests
    {
        private MockRepository _mockRepository;
        private IRepository<Format> _formatRepository;

        private IFormatService _formatService;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _formatRepository = _mockRepository.DynamicMock<IRepository<Format>>();

            _formatService = new FormatService(_formatRepository);
        }

        [Test]
        public void GetAllFormats_CorrectCount()
        {
            using (_mockRepository.Record())
            {
                _formatRepository.Stub(x => x.Table)
                    .Return((new List<Format> { new Format() })
                                .AsQueryable());
            }

            var result = _formatService.GetAllFormats(0, 1);

            Assert.AreEqual(result.Count(), 1);
        }

        [Test]
        public void GetAllFormats_WithPaging_CorrectCount()
        {
            var formats = new List<Format>();
            for (int i = 0; i < 6; i++)
            {
                formats.Add(new Format());
            }

            using (_mockRepository.Record())
            {
                _formatRepository.Stub(x => x.Table)
                    .Return(formats.AsQueryable());
            }

            var result = _formatService.GetAllFormats(1, 4);

            Assert.AreEqual(result.Count(), 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteFormat_FormatIsNull_Exception()
        {
            _formatService.DeleteFormat(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateFormat_FormatIsNull_Exception()
        {
            _formatService.UpdateFormat(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertFormat_FormatIsNull_Exception()
        {
            _formatService.InsertFormat(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetFormatById_IdIsEmpty_Exception()
        {
            _formatService.GetFormatById(Guid.Empty);
        }

        [Test]
        public void GetFormatById_Founded()
        {
            var id = Guid.NewGuid();
            var format = new Format() { Id = id };

            using (_mockRepository.Record())
            {
                _formatRepository.Stub(x => x.Find(y => y.Id == Guid.Empty))
                    .IgnoreArguments()
                    .Return(new List<Format>
                                {
                                    format
                                });
            }

            var result = _formatService.GetFormatById(id);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetFormatById_NotFound_ReturnNull()
        {
            var id = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _formatRepository.Stub(x => x.Find(y => y.Id == Guid.Empty))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _formatService.GetFormatById(id);

            Assert.IsNull(result);
        }
    }
}
