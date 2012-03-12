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
        [ExpectedException(typeof(ArgumentNullException))]
        public void Update_FormatIsNull_Exception()
        {
            _formatService.Update(null);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Update_NotFound_ReturnException()
        {
            using (_mockRepository.Record())
            {
                _formatRepository.Stub(x => x.Find(y => y.Id == Guid.Empty))
                    .IgnoreArguments()
                    .Return(null);
            }

            _formatService.Update(new Format());
        }

        [Test]
        public void GetAll_CountCorrect()
        {
            using (_mockRepository.Record())
            {
                _formatRepository.Stub(x => x.Table)
                    .IgnoreArguments()
                    .Return(new List<Format>
                                {
                                    new Format()
                                }
                                .AsQueryable());
            }

            var result = _formatService.GetAll();
            Assert.AreEqual(result.Count, 1);
        }

        [Test]
        public void GetAll_OrderingCorrect()
        {
            using (_mockRepository.Record())
            {
                _formatRepository.Stub(x => x.Table)
                    .IgnoreArguments()
                    .Return(new List<Format>
                                {
                                    new Format { Name = "re" },
                                    new Format { Name = "ds" },
                                    new Format { Name = "ss" }
                                }
                                .AsQueryable());
            }

            var result = _formatService.GetAll();
            Assert.AreEqual(result[0].Name, "ds");
            Assert.AreEqual(result[1].Name, "re");
            Assert.AreEqual(result[2].Name, "ss");
        }
    }
}
