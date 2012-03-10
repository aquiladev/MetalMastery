using System.Data.Entity.ModelConfiguration;
using MetalMastery.Core.Domain;

namespace MetalMastery.Data.Mapping
{
	public class UserMap : EntityTypeConfiguration<User>
	{
		public UserMap()
		{
			// Primary Key
			HasKey(t => t.Id);

			// Properties
			Property(t => t.Email)
				.IsRequired()
				.HasMaxLength(256);
				
			Property(t => t.Password)
				.IsRequired()
				.HasMaxLength(32);
				
			// Table & Column Mappings
			ToTable("User");
			Property(t => t.Id).HasColumnName("Id");
			Property(t => t.Email).HasColumnName("Email");
			Property(t => t.Password).HasColumnName("Password");
			Property(t => t.IsAdmin).HasColumnName("IsAdmin");
		}
	}
}

