using Microsoft.EntityFrameworkCore;
using MVC_Project__online_shop_.Entities;

namespace MVC_Project__online_shop_.Data
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}