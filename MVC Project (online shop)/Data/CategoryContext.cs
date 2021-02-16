using Microsoft.EntityFrameworkCore;
using MVC_Project__online_shop_.Models;

namespace MVC_Project__online_shop_.Data
{
    public class CategoryContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public CategoryContext(DbContextOptions<CategoryContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
