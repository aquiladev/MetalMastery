using System;

namespace MetalMastery.Core.Domain
{
	public class Order : BaseEntity
	{
		public new Guid Id { get; set; }
		
        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public Guid OwnerId { get; set; }

        public Guid StateId { get; set; }
		
        public Guid ThingId { get; set; }
		
        public virtual OrderState State { get; set; }
		
        public virtual Thing Thing { get; set; }

        public virtual User Owner { get; set; }
	}
}

