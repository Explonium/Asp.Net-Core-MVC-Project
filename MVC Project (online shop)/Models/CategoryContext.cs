using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project__online_shop_.Models
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
