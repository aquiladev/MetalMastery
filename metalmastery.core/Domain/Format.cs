using System;
using System.Collections.Generic;

namespace MetalMastery.Core.Domain
{
	public class Format : BaseEntity
	{
	    public Format()
		{
			Things = new List<Thing>();
		}

		public Guid Id { get; set; }
		
        public string Name { get; set; }
		
        public virtual ICollection<Thing> Things { get; set; }
	}
}

