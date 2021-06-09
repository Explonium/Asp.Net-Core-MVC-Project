using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatMember> ChatMembers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Deliverer> Deliverers { get; set; }
        public DbSet<DeliveryRoute> DeliveryRoutes { get; set; }
        public DbSet<Dispute> Disputes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Waybill> Waybills { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SubCategory>()
                .HasOne(p => p.Category)
                .WithMany(p => p.SubCategories);

            builder.Entity<Product>()
                .HasOne(p => p.SubCategory)
                .WithMany(p => p.Products);

            builder.Entity<Country>()
                .HasOne(p => p.DefaultCurrency)
                .WithMany(p => p.Countries);

            builder.Entity<City>()
                .HasOne(p => p.Country)
                .WithMany(p => p.Cities);

            builder.Entity<User>()
                .HasOne(p => p.City)
                .WithMany(p => p.Users);

            builder.Entity<User>()
                .HasOne(p => p.Deliverer)
                .WithOne(p => p.User);

            builder.Entity<DeliveryRoute>()
                .HasOne(p => p.Deliverer)
                .WithMany(p => p.DeliveryRoutes);

            /*
            builder.Entity<DeliveryRoute>()
                .HasOne(p => p.CountryFrom)
                .WithMany(p => p.DeliveryRoutesFrom);

            builder.Entity<DeliveryRoute>()
                .HasOne(p => p.CountryTo)
                .WithMany(p => p.DeliveryRoutesTo);
            */

            builder.Entity<User>()
                .HasOne(p => p.Vendor)
                .WithOne(p => p.User);

            builder.Entity<Storage>()
                .HasOne(p => p.City)
                .WithMany(p => p.Storages);

            builder.Entity<Storage>()
                .HasOne(p => p.Vendor)
                .WithMany(p => p.Storages);

            builder.Entity<Stock>()
                .HasOne(p => p.Storage)
                .WithMany(p => p.Stocks);

            builder.Entity<Product>()
                .HasOne(p => p.Vendor)
                .WithMany(p => p.Products);

            builder.Entity<Product>()
                .HasOne(p => p.Manufacturer)
                .WithMany(p => p.Products);

            builder.Entity<ProductVariant>()
                .HasOne(p => p.Product)
                .WithMany(p => p.ProductVariants);

            builder.Entity<Stock>()
                .HasOne(p => p.ProductVariant)
                .WithMany(p => p.Stocks);

            builder.Entity<ChatMember>()
                .HasOne(p => p.Chat)
                .WithMany(p => p.ChatMembers);

            builder.Entity<ChatMember>()
                .HasOne(p => p.User)
                .WithMany(p => p.ChatMembers);

            base.OnModelCreating(builder);
        }
    }
}
