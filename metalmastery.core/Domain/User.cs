using System;
using System.Collections.Generic;

namespace MetalMastery.Core.Domain
{
	public class User : BaseEntity
	{
	    public User()
		{
			Orders = new List<Order>();
            Articles = new List<Article>();
            //Things = new List<Thing>();
		}

		public new Guid Id { get; set; }
		
        public string Email { get; set; }

	    public byte[] Password { get; set; }

	    public bool IsAdmin { get; set; }
		
        public ICollection<Order> Orders { get; set; }

        //public virtual ICollection<Thing> Things { get; set; }

        public ICollection<Article> Articles { get; set; }
	}
}

