using System;

namespace MetalMastery.Core.Domain
{
	public class Order : BaseEntity
	{
		public new Guid Id { get; set; }
		
        public DateTime CreateDate { get; set; }
		
        public Guid UserId { get; set; }
		
        public Guid StateOrderId { get; set; }
		
        public Guid ThingId { get; set; }
		
        public virtual StateOrder StateOrder { get; set; }
		
        public virtual Thing Thing { get; set; }
		
        public virtual User User { get; set; }
	}
}

