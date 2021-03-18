using Microsoft.EntityFrameworkCore;
using MVC_Project__online_shop_.Entities;

namespace MVC_Project__online_shop_.Data
{
    public class CategoryContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        public CategoryContext(DbContextOptions<CategoryContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubCategory>()
                .HasOne(p => p.Category)
                .WithMany(p => p.SubCategories);

            base.OnModelCreating(modelBuilder);
        }
    }
}
