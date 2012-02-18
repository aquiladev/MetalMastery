using System;
using System.Collections.Generic;

namespace MetalMastery.Core.Domain
{
	public class User
	{
	    public User()
		{
			Orders = new List<Order>();
            Articles = new List<Article>();
            //Things = new List<Thing>();
		}

		public Guid Id { get; set; }
		
        public string Email { get; set; }
		
        public string Password { get; set; }
		
        public Guid RoleId { get; set; }
		
        public virtual ICollection<Order> Orders { get; set; }
		
        public virtual Role Role { get; set; }

        //public virtual ICollection<Thing> Things { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
	}
}

