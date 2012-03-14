using System;
using System.Collections.Generic;

namespace MetalMastery.Core.Domain
{
	public sealed class StateOrder : BaseEntity
	{
	    public StateOrder()
		{
			Orders = new List<Order>();
		}

		public new Guid Id { get; set; }
		
        public string Name { get; set; }
		
        public ICollection<Order> Orders { get; set; }
	}
}

