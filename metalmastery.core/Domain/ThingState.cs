using System;
using System.Collections.Generic;

namespace MetalMastery.Core.Domain
{
    public class ThingState : BaseEntity
    {
        public ThingState()
        {
            Things = new List<Thing>();
        }

        public new Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Thing> Things { get; set; }
    }
}

