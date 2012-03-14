using System;
using System.Collections.Generic;
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
        
        public State GetStateByName(string name)
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

        public List<State> GetAll()
        {
            return _stateRepository
                .Table
                .OrderBy(t => t.Name)
                .ToList();
        }
    }
}
