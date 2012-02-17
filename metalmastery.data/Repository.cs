using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MetalMastery.Core.Data;

namespace MetalMastery.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IDbContext _dataContext;
        private readonly IDbSet<T> _entity;

        public Repository(IDbContext context)
        {
            _dataContext = context;
            _entity = _dataContext.Set<T>();
        }
        
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _entity.Where<T>(predicate);
        }
        
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _entity.Add(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _entity.Remove(entity);
        }

        public IQueryable<T> Table
        {
            get { return _entity; }
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dataContext != null)
                {
                    _dataContext.Dispose();
                    _dataContext = null;
                }
            }
        }
    }
}
