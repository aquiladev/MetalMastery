using System;
using System.Linq;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;
using MetalMastery.Services.Interfaces;

namespace MetalMastery.Services
{
    public class StateService : BaseEntityService<State>, IStateService
    {
        private readonly IRepository<State> _stateRepository;
        
        public StateService(IRepository<State> stateRepository)
            : base(stateRepository)
        {
            _stateRepository = stateRepository;
        }
        
        public State GetThingByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            var things = _stateRepository.Find(u => u.Name == name);
            return things == null
                ? null
                : things.FirstOrDefault();
        }
    }
}
