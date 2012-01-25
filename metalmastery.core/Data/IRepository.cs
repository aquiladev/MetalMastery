using System;
using System.Linq;

namespace MetalMastery.Core.Data
{
    public partial interface IRepository<T> : IDisposable where T : class
    {
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
        void SaveChanges();
    }
}
