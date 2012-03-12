using System;
using MetalMastery.Core.Data;
using MetalMastery.Core.Domain;
using MetalMastery.Services.Interfaces;

namespace MetalMastery.Services
{
    public class ThingService : BaseEntityService<Thing>, IThingService
    {
        private readonly IRepository<Thing> _thingRepository;

        public ThingService(IRepository<Thing> thingRepository) 
            : base(thingRepository)
        {
            _thingRepository = thingRepository;
        }
        
        public override void Update(Thing thing)
        {
            throw new NotImplementedException();
        }
    }
}
