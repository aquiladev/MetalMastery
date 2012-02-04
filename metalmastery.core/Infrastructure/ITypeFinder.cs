using System.Collections.Generic;
using System.Reflection;

namespace MetalMastery.Core.Infrastructure
{
    public interface ITypeFinder
    {
        IList<Assembly> GetAssemblies();
    }
}
