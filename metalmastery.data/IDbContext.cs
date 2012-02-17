using System;
using System.Data.Entity;

namespace MetalMastery.Data
{
    public interface IDbContext : IDisposable
    {
        IDbSet<T> Set<T>() where T : class;

        int SaveChanges();
    }
}
