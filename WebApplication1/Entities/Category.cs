using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }

        // Relations

        [InverseProperty("Category")]
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
