using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project__online_shop_.Models
{
    public class CategoryCreationModel
    {
        public Guid Id { get; set; } = new Guid();

        [Required(ErrorMessage = "Name of category is required")]
        public string Name { get; set; }

        public string IconPath { get; set; } = "~/icons/default_category_icon.svg";
    }
}
