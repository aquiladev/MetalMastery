using System.Collections.Generic;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services.Interfaces
{
    public interface IStateService : IBaseEntityService<State>
    {
        State GetStateByName(string name);

        List<State> GetAll();
    }
}
