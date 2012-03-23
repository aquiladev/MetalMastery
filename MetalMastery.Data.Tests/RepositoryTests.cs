using System;
using System.Data.Entity;
using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;

namespace MetalMastery.Data.Tests
{
    [TestFixture]
    public class RepositoryTests
    {
        private IDbContext _dbContext;
        private IDbSet<String> _dbSet;
        private MockRepository _mockRepository;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository();

            _dbContext = _mockRepository.DynamicMock<IDbContext>();
            _dbSet = new FakeDbSet<string>();
        }

        [Test]
        public void Table_SetIsNull()
        {
            using (_mockRepository.Record())
            {
                _dbContext.Stub(x => x.Set<String>())
                    .IgnoreArguments()
                    .Return(null);
            }

            var result = new Repository<String>(_dbContext).Table;

            Assert.IsNull(result);
        }

        [Test]
        public void Table_SetIsEmpty()
        {
            using (_mockRepository.Record())
            {
                _dbContext.Stub(x => x.Set<String>())
                    .IgnoreArguments()
                    .Return(_dbSet);
            }

            var result = new Repository<String>(_dbContext).Table;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 0);
        }

        [Test]
        public void Table_SetIsCorrect()
        {
            _dbSet.Add("test");
            _dbSet.Add("test1");

            using (_mockRepository.Record())
            {
                _dbContext.Stub(x => x.Set<String>())
                    .IgnoreArguments()
                    .Return(_dbSet);
            }

            var result = new Repository<String>(_dbContext).Table;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Insert_EntityIsNull_ReturnException()
        {
            new Repository<String>(_dbContext).Insert(null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void Insert_SetIsNull_ReturnException()
        {
            new Repository<String>(_dbContext).Insert("test");
        }

        [Test]
        public void Insert_SetIsCorrect()
        {
            const string entity = "ent";

            using (_mockRepository.Record())
            {
                _dbContext.Stub(x => x.Set<String>())
                    .IgnoreArguments()
                    .Return(_dbSet);
            }

            new Repository<String>(_dbContext).Insert(entity);

            Assert.AreEqual(_dbSet.First(), entity);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Delete_EntityIsNull_ReturnException()
        {
            new Repository<String>(_dbContext).Delete(null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void Delete_SetIsNull_ReturnException()
        {
            new Repository<String>(_dbContext).Delete("ds");
        }

        [Test]
        public void Delete_SetIsCorrect()
        {
            const string entity = "ent";
            _dbSet.Add(entity);

            using (_mockRepository.Record())
            {
                _dbContext.Stub(x => x.Set<String>())
                    .IgnoreArguments()
                    .Return(_dbSet);
            }

            new Repository<String>(_dbContext).Delete(entity);

            Assert.AreEqual(_dbSet.Count(), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Find_EntityIsNull_ReturnException()
        {
            new Repository<String>(_dbContext).Find(x => x == "temp");
        }

        [Test]
        public void Find_EntityNotFound()
        {
            using (_mockRepository.Record())
            {
                _dbContext.Stub(x => x.Set<String>())
                    .IgnoreArguments()
                    .Return(_dbSet);
            }

            var result = new Repository<String>(_dbContext).Find(x => x == "temp");

            Assert.AreEqual(result.Count(), 0);
        }

        [Test]
        public void Find_EntityFound()
        {
            const string entity = "etn";
            _dbSet.Add(entity);

            using (_mockRepository.Record())
            {
                _dbContext.Stub(x => x.Set<String>())
                    .IgnoreArguments()
                    .Return(_dbSet);
            }

            var result = new Repository<String>(_dbContext).Find(x => x == entity);

            Assert.AreEqual(result.Count(), 1);
        }

        [Test]
        public void SaveChanges_ExpectCallSaveChanges()
        {
            using (_mockRepository.Record())
            {
                _dbContext.Expect(x => x.SaveChanges())
                    .Return(0);
            }

            new Repository<String>(_dbContext).SaveChanges();

            _mockRepository.VerifyAll();
        }
    }
}
