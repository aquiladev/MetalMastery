using System.Collections.Generic;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services.Interfaces
{
    public interface IFormatService : IBaseEntityService<Format>
    {
        List<Format> GetAll();
    }
}
