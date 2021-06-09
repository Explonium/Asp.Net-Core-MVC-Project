using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class SubCategoryCreationModel
    {
        public Guid Id { get; set; } = new Guid();
        [Required]
        public string Name { get; set; }
        public string IconPath { get; set; } = "~/icons/default_subcategory_icon.svg";
        [Required]
        public Guid CategoryId { get; set; }
    }
}
