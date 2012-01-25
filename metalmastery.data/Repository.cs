using System;
using System.Data.Objects;
using System.Linq;
using MetalMastery.Core.Data;

namespace MetalMastery.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ObjectContext _dataContext;
        private IObjectSet<T> _entity;

        public Repository(ObjectContext context)
        {
            _dataContext = context;
            _entity = _dataContext.CreateObjectSet<T>();
        }

        public T GetById(int id)
        {
            throw new System.NotImplementedException(); 
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _entity.AddObject(entity);
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _entity.DeleteObject(entity);
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
