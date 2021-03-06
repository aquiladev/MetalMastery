using System;
using System.Collections.Generic;

namespace MetalMastery.Core.Domain
{
	public class OrderState : BaseEntity
	{
	    public OrderState()
		{
			Orders = new List<Order>();
		}

		public new Guid Id { get; set; }
		
        public string Name { get; set; }
		
        public virtual ICollection<Order> Orders { get; set; }
	}
}

