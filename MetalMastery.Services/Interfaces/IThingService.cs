using MetalMastery.Core;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services.Interfaces
{
    public interface IThingService : IBaseEntityService<Thing>
    {
        IPagedList<Thing> GetPublishedThings(int pageIndex, int pageSize);
    }
}
