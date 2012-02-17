using System.Data.Entity.ModelConfiguration;
using MetalMastery.Core.Domain;

namespace MetalMastery.Data.Mapping
{
	public class TagMap : EntityTypeConfiguration<Tag>
	{
		public TagMap()
		{
			// Primary Key
			HasKey(t => t.Id);

			// Properties
			Property(t => t.Name)
				.IsRequired()
				.HasMaxLength(32);
				
			// Table & Column Mappings
			ToTable("Tag");
			Property(t => t.Id).HasColumnName("Id");
			Property(t => t.Name).HasColumnName("Name");

			// Relationships
			HasMany(t => t.Things)
			    .WithMany(t => t.Tags)
				.Map(m =>
                    {
                        m.ToTable("ThingTag");
                        m.MapLeftKey("TagId");
                        m.MapRightKey("ThingId");
                    });
					
		}
	}
}

