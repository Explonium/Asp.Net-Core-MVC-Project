using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project__online_shop_.Entities
{
    public class Country
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
