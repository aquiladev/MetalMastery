using System.Collections.Generic;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services.Interfaces
{
    public interface ITagService : IBaseEntityService<Tag>
    {
        List<Tag> GetAll();
    }
}
