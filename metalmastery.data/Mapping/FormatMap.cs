using System.Data.Entity.ModelConfiguration;
using MetalMastery.Core.Domain;

namespace MetalMastery.Data.Mapping
{
	public class FormatMap : EntityTypeConfiguration<Format>
	{
		public FormatMap()
		{
			// Primary Key
			HasKey(t => t.Id);

			// Properties
			Property(t => t.Name)
				.IsRequired()
				.HasMaxLength(32);
				
			// Table & Column Mappings
			ToTable("Format");
			Property(t => t.Id).HasColumnName("Id");
			Property(t => t.Name).HasColumnName("Name");
		}
	}
}

