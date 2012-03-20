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
			Property(t => t.UpdateDate).HasColumnName("UpdateDate");
			Property(t => t.OwnerId).HasColumnName("OwnerId");
			Property(t => t.StateId).HasColumnName("StateId");
			Property(t => t.ThingId).HasColumnName("ThingId");

			// Relationships
			HasRequired(t => t.State)
				.WithMany(t => t.Orders)
				.HasForeignKey(d => d.StateId);
				
			HasRequired(t => t.Thing)
				.WithMany(t => t.Orders)
				.HasForeignKey(d => d.ThingId);
				
			HasRequired(t => t.Owner)
				.WithMany(t => t.Orders)
				.HasForeignKey(d => d.OwnerId);
				
		}
	}
}

