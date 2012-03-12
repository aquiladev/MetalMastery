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
    public class TagServiceTests
    {
        private MockRepository _mockRepository;
        private IRepository<Tag> _tagRepository;

        private ITagService _tagService;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();
            _tagRepository = _mockRepository.DynamicMock<IRepository<Tag>>();

            _tagService = new TagService(_tagRepository);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateTag_TagIsNull_Exception()
        {
            _tagService.Update(null);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Update_NotFound_ReturnException()
        {
            using (_mockRepository.Record())
            {
                _tagRepository.Stub(x => x.Find(y => y.Id == Guid.Empty))
                    .IgnoreArguments()
                    .Return(null);
            }

            _tagService.Update(new Tag());
        }

        [Test]
        public void GetAll_CountCorrect()
        {
            using (_mockRepository.Record())
            {
                _tagRepository.Stub(x => x.Table)
                    .IgnoreArguments()
                    .Return(new List<Tag>
                                {
                                    new Tag()
                                }
                                .AsQueryable());
            }

            var result = _tagService.GetAll();
            Assert.AreEqual(result.Count, 1);
        }

        [Test]
        public void GetAll_OrderingCorrect()
        {
            using (_mockRepository.Record())
            {
                _tagRepository.Stub(x => x.Table)
                    .IgnoreArguments()
                    .Return(new List<Tag>
                                {
                                    new Tag { Name = "re" },
                                    new Tag { Name = "ds" },
                                    new Tag { Name = "ss" }
                                }
                                .AsQueryable());
            }

            var result = _tagService.GetAll();
            Assert.AreEqual(result[0].Name, "ds");
            Assert.AreEqual(result[1].Name, "re");
            Assert.AreEqual(result[2].Name, "ss");
        }
    }
}
