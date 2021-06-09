using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class SubCategory
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }

        // Relations

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [InverseProperty("SubCategory")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
