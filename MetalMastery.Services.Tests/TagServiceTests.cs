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
        public void GetAllTags_CorrectCount()
        {
            using (_mockRepository.Record())
            {
                _tagRepository.Stub(x => x.Table)
                    .Return((new List<Tag> { new Tag() })
                                .AsQueryable());
            }

            var result = _tagService.GetAllTags(0, 1);

            Assert.AreEqual(result.Count(), 1);
        }

        [Test]
        public void GetAllTags_WithPaging_CorrectCount()
        {
            var tags = new List<Tag>();
            for (int i = 0; i < 6; i++)
            {
                tags.Add(new Tag());
            }

            using (_mockRepository.Record())
            {
                _tagRepository.Stub(x => x.Table)
                    .Return(tags.AsQueryable());
            }

            var result = _tagService.GetAllTags(1, 4);

            Assert.AreEqual(result.Count(), 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteTag_TagIsNull_Exception()
        {
            _tagService.DeleteTag(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateTag_TagIsNull_Exception()
        {
            _tagService.UpdateTag(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertTag_TagIsNull_Exception()
        {
            _tagService.InsertTag(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetTagById_IdIsEmpty_Exception()
        {
            _tagService.GetTagById(Guid.Empty);
        }

        [Test]
        public void GetTagById_Founded()
        {
            var id = Guid.NewGuid();
            var tag = new Tag { Id = id };

            using (_mockRepository.Record())
            {
                _tagRepository.Stub(x => x.Find(y => y.Id == Guid.Empty))
                    .IgnoreArguments()
                    .Return(new List<Tag>
                                {
                                    tag
                                });
            }

            var result = _tagService.GetTagById(id);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetTagById_NotFound_ReturnNull()
        {
            var id = Guid.NewGuid();

            using (_mockRepository.Record())
            {
                _tagRepository.Stub(x => x.Find(y => y.Id == Guid.Empty))
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = _tagService.GetTagById(id);

            Assert.IsNull(result);
        }
    }
}
