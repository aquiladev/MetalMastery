using System.Data.Entity.ModelConfiguration;
using MetalMastery.Core.Domain;

namespace MetalMastery.Data.Mapping
{
	public class OrderMap : EntityTypeConfiguration<Order>
	{
		public OrderMap()
		{
			// Primary Key
			HasKey(t => t.Id);

			// Properties
			// Table & Column Mappings
			ToTable("Order");
			Property(t => t.Id).HasColumnName("Id");
			Property(t => t.CreateDate).HasColumnName("CreateDate");
			Property(t => t.UserId).HasColumnName("UserId");
			Property(t => t.StateOrderId).HasColumnName("StateOrderId");
			Property(t => t.ThingId).HasColumnName("ThingId");

			// Relationships
			HasRequired(t => t.StateOrder)
				.WithMany(t => t.Orders)
				.HasForeignKey(d => d.StateOrderId);
				
			HasRequired(t => t.Thing)
				.WithMany(t => t.Orders)
				.HasForeignKey(d => d.ThingId);
				
			HasRequired(t => t.User)
				.WithMany(t => t.Orders)
				.HasForeignKey(d => d.UserId);
				
		}
	}
}

