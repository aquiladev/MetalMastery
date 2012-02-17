using System.Data.Entity.ModelConfiguration;
using MetalMastery.Core.Domain;

namespace MetalMastery.Data.Mapping
{
    public class ArticleMap : EntityTypeConfiguration<Article>
    {
        public ArticleMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);

            Property(t => t.Text)
                .IsRequired();

            Property(t => t.CreateDate)
                .IsRequired();

            // Table & Column Mappings
            ToTable("Order");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.CreateDate).HasColumnName("CreateDate");
            Property(t => t.Title).HasColumnName("Title");
            Property(t => t.Text).HasColumnName("Text");
            Property(t => t.OwnerId).HasColumnName("OwnerId");

            // Relationships
            HasRequired(t => t.Owner)
                .WithMany(t => t.Articles)
                .HasForeignKey(d => d.OwnerId);
        }
    }
}
