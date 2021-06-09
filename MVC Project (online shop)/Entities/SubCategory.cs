using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    public class SubCategory
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
        public Guid CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
