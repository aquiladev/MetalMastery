using MetalMastery.Core.Domain;

namespace MetalMastery.Services.Interfaces
{
    public interface IStateService : IBaseEntityService<State>
    {
        State GetThingByName(string name);
    }
}
