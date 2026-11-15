namespace AutoMarket.Data
{
    using AutoMarket.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Identity.Client;

    public class AutoMarketDbContext : DbContext
    {
        public AutoMarketDbContext(DbContextOptions<AutoMarketDbContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;

        public virtual DbSet<Model> Models { get; set; } = null!;

        public virtual DbSet<CarListing> CarListings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(AutoMarketDbContext).Assembly);
        }
    }
}
