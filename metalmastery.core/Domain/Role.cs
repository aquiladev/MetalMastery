using System;
using System.Collections.Generic;

namespace MetalMastery.Core.Domain
{
	public class Role
	{
	    public Role()
		{
			Users = new List<User>();
		}

		public Guid Id { get; set; }
		
        public string Name { get; set; }
		
        public virtual ICollection<User> Users { get; set; }
	}
}

