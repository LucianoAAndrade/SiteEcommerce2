using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SiteECommerce.Models
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext() : base("DefaultConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<SiteECommerce.Models.Departaments> Departaments { get; set; }

        public System.Data.Entity.DbSet<SiteECommerce.Models.City> Cities { get; set; }

        public System.Data.Entity.DbSet<SiteECommerce.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<SiteECommerce.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<SiteECommerce.Models.Category> Categories { get; set; }
    }
}