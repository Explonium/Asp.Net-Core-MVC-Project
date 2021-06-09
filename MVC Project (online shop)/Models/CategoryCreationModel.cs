using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CategoryCreationModel
    {
        public Guid Id { get; set; } = new Guid();

        [Required(ErrorMessage = "Name of category is required")]
        public string Name { get; set; }

        public string IconPath { get; set; } = "~/icons/default_category_icon.svg";
    }
}
