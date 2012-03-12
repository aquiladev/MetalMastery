using System.Collections.Generic;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services.Interfaces
{
    public interface IMaterialService : IBaseEntityService<Material>
    {
        List<Material> GetAll();
    }
}
