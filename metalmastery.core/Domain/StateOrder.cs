using System;
using System.Collections.Generic;

namespace MetalMastery.Core.Domain
{
	public class StateOrder : BaseEntity
	{
	    public StateOrder()
		{
			Orders = new List<Order>();
		}

		public Guid Id { get; set; }
		
        public string Name { get; set; }
		
        public virtual ICollection<Order> Orders { get; set; }
	}
}

