using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class MvcProjectContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public MvcProjectContext(DbContextOptions<MvcProjectContext> options)
        : base(options)
        {
            //Database.EnsureCreated();
        }

    }
}
