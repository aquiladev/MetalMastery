using System;
using System.Collections.Generic;

namespace MetalMastery.Core.Domain
{
	public class Thing : BaseEntity
	{
	    public Thing()
		{
			Orders = new List<Order>();
			Tags = new List<Tag>();
		}

		public new Guid Id { get; set; }

		public string Name { get; set; }
		
        public string Description { get; set; }
		
        public bool ShowOnHome { get; set; }
		
        public bool ShowForAll { get; set; }
		
        public Guid FormatId { get; set; }
		
        public int Rating { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }
		
        public string Comment { get; set; }

        public string ImageRes { get; set; }

        public DateTime CreateDate { get; set; }
		
        public Guid MaterialId { get; set; }
		
        public Guid StateId { get; set; }

        public Format Format { get; set; }
		
        public Material Material { get; set; }
		
        public ICollection<Order> Orders { get; set; }
		
        public State State { get; set; }
		
        public ICollection<Tag> Tags { get; set; }

        //public Guid OwnerId { get; set; }

        //public virtual User Owner { get; set; }
	}
}

