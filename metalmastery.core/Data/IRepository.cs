using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MetalMastery.Core.Data
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
        void SaveChanges();
    }
}
