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

		public new Guid Id { get; set; }
		
        public string Name { get; set; }
		
        public ICollection<Thing> Things { get; set; }
	}
}

