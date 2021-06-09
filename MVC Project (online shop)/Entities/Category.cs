using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }

        [InverseProperty("CategoryId")]
        public ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
    }
}
