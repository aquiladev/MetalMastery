using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace MetalMastery.Core.Tests
{
    [TestFixture]
    public class PagedListTests
    {
        private List<string> _collection;
        private int countItem = 10;

        [SetUp]
        public void SetUp()
        {
            _collection = new List<string>();
            for (int i = 0; i < countItem; i++)
            {
                _collection.Add("test" + i);
            }
        }

        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void PagedList_DivideByZero_Exception()
        {
            new PagedList<string>(new List<string>(), 0, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PagedList_CollectionIsNull_Exception()
        {
            new PagedList<string>((IQueryable<string>)null, 0, 0);
        }

        [Test]
        [TestCase(0)]
        [TestCase(3)]
        [TestCase(9)]
        public void PagedList_GetPageByIndex(int index)
        {
            int size = 1;
            var l = new PagedList<string>(_collection, index, size);
            
            Assert.AreEqual(l.PageIndex, index);
            Assert.AreEqual(l[0], "test" + index);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(10)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PagedList_GetPageByIndexOutOfRange_Exception(int index)
        {
            int size = 1;
            new PagedList<string>(_collection, index, size);
        }

        [Test]
        public void PagedList_GetFirstPage()
        {
            int index = 0;
            int size = 1;
            var l = new PagedList<string>(_collection, index, size);

            Assert.AreEqual(l.HasNextPage, true);
            Assert.AreEqual(l.HasPreviousPage, false);
        }

        [Test]
        public void PagedList_GetLastPage()
        {
            int index = 9;
            int size = 1;
            var l = new PagedList<string>(_collection, index, size);

            Assert.AreEqual(l.HasNextPage, false);
            Assert.AreEqual(l.HasPreviousPage, true);
        }

        [Test]
        public void PagedList_CorrectInit()
        {
            int index = 0;
            int size = 1;
            var l = new PagedList<string>(_collection, index, size);

            Assert.AreEqual(l.HasNextPage, true);
            Assert.AreEqual(l.HasPreviousPage, false);
            Assert.AreEqual(l.PageIndex, index);
            Assert.AreEqual(l.PageSize, size);
            Assert.AreEqual(l.TotalCount, countItem);
            Assert.AreEqual(l.TotalPages, countItem);
        }

        [Test]
        public void PagedList_ThreeItemOnPage()
        {
            int index = 3;
            int size = 3;
            var l = new PagedList<string>(_collection, index, size);

            Assert.AreEqual(l.TotalPages, 4);
            Assert.AreEqual(l.Count, 1);
        }
    }
}
