using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project__online_shop_.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
    }
}
