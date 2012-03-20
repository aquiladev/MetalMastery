using System.Data.Entity.ModelConfiguration;
using MetalMastery.Core.Domain;

namespace MetalMastery.Data.Mapping
{
	public class ThingMap : EntityTypeConfiguration<Thing>
	{
		public ThingMap()
		{
			// Primary Key
			HasKey(t => t.Id);

			// Properties
			Property(t => t.Name)
				.IsRequired()
				.HasMaxLength(256);
				
			Property(t => t.Description)
				.IsRequired();
				
			Property(t => t.Comment)
				.HasMaxLength(1024);
				
			Property(t => t.ImageRes)
				.IsRequired();

            Property(t => t.CreateDate)
                .IsRequired();
				
			// Table & Column Mappings
			ToTable("Thing");
			Property(t => t.Id).HasColumnName("Id");
			Property(t => t.Name).HasColumnName("Name");
			Property(t => t.Description).HasColumnName("Description");
			Property(t => t.ShowOnHome).HasColumnName("ShowOnHome");
			Property(t => t.ShowForAll).HasColumnName("ShowForAll");
			Property(t => t.FormatId).HasColumnName("FormatId");
			Property(t => t.Rating).HasColumnName("Rating");
			Property(t => t.Price).HasColumnName("Price");
			Property(t => t.Image1).HasColumnName("Image1");
			Property(t => t.Image2).HasColumnName("Image2");
			Property(t => t.Comment).HasColumnName("Comment");
            Property(t => t.CreateDate).HasColumnName("CreateDate");
			Property(t => t.ImageRes).HasColumnName("ImageRes");
			Property(t => t.MaterialId).HasColumnName("MaterialId");
			Property(t => t.StateId).HasColumnName("StateId");
            Property(t => t.OwnerId).HasColumnName("OwnerId");

			// Relationships
			HasRequired(t => t.Format)
				.WithMany(t => t.Things)
				.HasForeignKey(d => d.FormatId);
				
			HasRequired(t => t.Material)
				.WithMany(t => t.Things)
				.HasForeignKey(d => d.MaterialId);

		    HasRequired(t => t.State)
		        .WithMany(t => t.Things)
		        .HasForeignKey(d => d.StateId);

            HasRequired(t => t.Owner)
                .WithMany(t => t.Things)
                .HasForeignKey(d => d.OwnerId);
		}
	}
}

