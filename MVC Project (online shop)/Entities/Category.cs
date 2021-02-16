using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project__online_shop_.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string IconPath { get; set; }
    }
}
