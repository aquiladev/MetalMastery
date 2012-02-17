using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MetalMastery.Core.Domain;
using MetalMastery.Data.Mapping;

namespace MetalMastery.Data
{
    public class MmDataContext : DbContext, IDbContext
    {
        public MmDataContext(string connectionString)
            : base(connectionString) { }

        public DbSet<Format> Formats { get; set; }
        
        public DbSet<Material> Materials { get; set; }
        
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<Role> Roles { get; set; }
        
        public DbSet<State> States { get; set; }
        
        public DbSet<StateOrder> StateOrders { get; set; }
        
        public DbSet<Tag> Tags { get; set; }
        
        public DbSet<Thing> Things { get; set; }
        
        public DbSet<User> Users { get; set; }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Configurations.Add(new FormatMap());
            modelBuilder.Configurations.Add(new MaterialMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new StateMap());
            modelBuilder.Configurations.Add(new StateOrderMap());
            modelBuilder.Configurations.Add(new TagMap());
            modelBuilder.Configurations.Add(new ThingMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new ArticleMap());

            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
