using Microsoft.EntityFrameworkCore;
using MVC_Project__online_shop_.Entities;

namespace MVC_Project__online_shop_.Data
{
    public class SubCategoryContext : DbContext
    {
        public DbSet<SubCategory> SubCategories { get; set; }

        public SubCategoryContext(DbContextOptions<SubCategoryContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
