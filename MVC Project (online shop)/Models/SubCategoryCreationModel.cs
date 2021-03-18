using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project__online_shop_.Models
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
