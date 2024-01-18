using LastFinal.Model;
using Microsoft.EntityFrameworkCore;

namespace LastFinal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<InsuranceProduct> InsuranceProducts { get; set; }
        public DbSet<AuthorizedUser> AuthorizedUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Typee> Typees { get; set; }
        public DbSet<Package> Packages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsuranceProduct>()
                .HasOne(ip => ip.AuthorizedUser)
                .WithMany(au => au.InsuranceProduct)
                .HasForeignKey(ip => ip.AuthorizedId);

            modelBuilder.Entity<InsuranceProduct>()
                .HasOne(ip => ip.Typee)
                .WithMany(t => t.InsuranceProducts)
                .HasForeignKey(ip => ip.TypeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
