using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcProjectApi.Entities;

namespace MvcProjectApi.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
            Database.OpenConnection();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DeliveryRoute>()
                .HasOne(p => p.CountryFrom)
                .WithMany(p => p.DeliveryRoutesFrom)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<DeliveryRoute>()
                .HasOne(p => p.CountryTo)
                .WithMany(p => p.DeliveryRoutesTo)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<DeliveryRoute>()
                .HasOne(p => p.Deliverer)
                .WithMany(p => p.DeliveryRoutes)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Stock>()
                .HasOne(p => p.Storage)
                .WithMany(p => p.Stocks)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Waybill>()
                .HasOne(p => p.Order)
                .WithMany(p => p.Waybills)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Supply>()
                .HasOne(p => p.Storage)
                .WithMany(p => p.Supplies)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<OrderSupply>()
                .HasOne(p => p.Stock)
                .WithMany(p => p.OrderSupplies)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<CartedProduct>()
                .HasOne(p => p.ProductVariant)
                .WithMany(p => p.CartedProducts)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }

        public DbSet<MvcProjectApi.Entities.Country> Country { get; set; }

        public DbSet<MvcProjectApi.Entities.Currency> Currency { get; set; }

        public DbSet<MvcProjectApi.Entities.City> City { get; set; }

        public DbSet<MvcProjectApi.Entities.Dispute> Dispute { get; set; }

        public DbSet<MvcProjectApi.Entities.Cart> Cart { get; set; }

        public DbSet<MvcProjectApi.Entities.CartedProduct> CartedProduct { get; set; }

        public DbSet<MvcProjectApi.Entities.Category> Category { get; set; }

        public DbSet<MvcProjectApi.Entities.Chat> Chat { get; set; }

        public DbSet<MvcProjectApi.Entities.ChatMember> ChatMember { get; set; }

        public DbSet<MvcProjectApi.Entities.Deliverer> Deliverer { get; set; }

        public DbSet<MvcProjectApi.Entities.DeliveryRoute> DeliveryRoute { get; set; }

        public DbSet<MvcProjectApi.Entities.DisputeReason> DisputeReason { get; set; }

        public DbSet<MvcProjectApi.Entities.Manufacturer> Manufacturer { get; set; }

        public DbSet<MvcProjectApi.Entities.Message> Message { get; set; }

        public DbSet<MvcProjectApi.Entities.Order> Order { get; set; }

        public DbSet<MvcProjectApi.Entities.OrderSupply> OrderSupply { get; set; }

        public DbSet<MvcProjectApi.Entities.Product> Product { get; set; }

        public DbSet<MvcProjectApi.Entities.ProductVariant> ProductVariant { get; set; }

        public DbSet<MvcProjectApi.Entities.Stock> Stock { get; set; }

        public DbSet<MvcProjectApi.Entities.Storage> Storage { get; set; }

        public DbSet<MvcProjectApi.Entities.SubCategory> SubCategory { get; set; }

        public DbSet<MvcProjectApi.Entities.Supply> Supply { get; set; }

        public DbSet<MvcProjectApi.Entities.Vendor> Vendor { get; set; }

        public DbSet<MvcProjectApi.Entities.Waybill> Waybill { get; set; }
    }
}
