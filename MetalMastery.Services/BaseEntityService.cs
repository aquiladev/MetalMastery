using System;
using System.Linq;
using MetalMastery.Core;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;
using MetalMastery.Services.Interfaces;

namespace MetalMastery.Services
{
    public class BaseEntityService<T> : IBaseEntityService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        public BaseEntityService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual IPagedList<T> GetAll(int pageIndex, int pageSize)
        {
            return new PagedList<T>(_repository
                                        .Table
                                        .ToList(),
                                    pageIndex,
                                    pageSize);
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _repository.Delete(entity);
            _repository.SaveChanges();
        }

        public virtual void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _repository.Insert(entity);
            _repository.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var entities = _repository.Find(x => x.Id == entity.Id);
            var entityFromRep = entities == null
                ? null
                : entities.FirstOrDefault();

            if (entityFromRep != null)
            {
                entityFromRep = entity;
                _repository.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Entity didn't found");
            }
        }

        public virtual T GetEntityById(Guid id)
        {
            if (id.Equals(default(Guid)))
            {
                throw new ArgumentNullException("id");
            }

            var entities = _repository.Find(u => u.Id == id);
            return entities == null
                ? null
                : entities.FirstOrDefault();
        }
    }
}
