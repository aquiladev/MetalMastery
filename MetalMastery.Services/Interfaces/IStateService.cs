using System.Collections.Generic;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services.Interfaces
{
    public interface IStateService : IBaseEntityService<ThingState>
    {
        ThingState GetStateByName(string name);

        List<ThingState> GetAll();
    }
}
