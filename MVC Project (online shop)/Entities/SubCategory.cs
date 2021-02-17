using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project__online_shop_.Entities
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
    }
}
