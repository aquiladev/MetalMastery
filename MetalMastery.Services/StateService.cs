using System;
using System.Collections.Generic;
using System.Linq;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;
using MetalMastery.Services.Interfaces;

namespace MetalMastery.Services
{
    public class StateService : BaseEntityService<ThingState>, IStateService
    {
        private readonly IRepository<ThingState> _stateRepository;
        
        public StateService(IRepository<ThingState> stateRepository)
            : base(stateRepository)
        {
            _stateRepository = stateRepository;
        }
        
        public ThingState GetStateByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            var states = _stateRepository.Find(u => u.Name == name);
            return states == null
                ? null
                : states.FirstOrDefault();
        }

        public List<ThingState> GetAll()
        {
            return _stateRepository
                .Table
                .OrderBy(t => t.Name)
                .ToList();
        }
    }
}
