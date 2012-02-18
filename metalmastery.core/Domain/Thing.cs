using System;
using System.Collections.Generic;

namespace MetalMastery.Core.Domain
{
	public class Thing
	{
	    public Thing()
		{
			Orders = new List<Order>();
			Tags = new List<Tag>();
		}

		public Guid Id { get; set; }

		public string Name { get; set; }
		
        public string Description { get; set; }
		
        public bool ShowOnHome { get; set; }
		
        public bool ShowForAll { get; set; }
		
        public Guid FormatId { get; set; }
		
        public Nullable<int> Rating { get; set; }
		
        public byte[] Image1 { get; set; }
		
        public byte[] Image2 { get; set; }
		
        public string Comment { get; set; }
		
        public byte[] ImageRes { get; set; }
		
        public Guid MaterialId { get; set; }
		
        public Guid StateId { get; set; }

        public Guid OwnerId { get; set; }
		
        public virtual Format Format { get; set; }
		
        public virtual Material Material { get; set; }
		
        public virtual ICollection<Order> Orders { get; set; }
		
        public virtual State State { get; set; }
		
        public virtual ICollection<Tag> Tags { get; set; }

        //public virtual User Owner { get; set; }
	}
}

