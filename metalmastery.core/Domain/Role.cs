using System;

namespace MetalMastery.Core.Domain
{
    public class Role
    {
        public Guid Id { get; protected set; }

        public string Name { get; set; }

        public Role()
        {
            Id = Guid.NewGuid();
        }
    }
}
