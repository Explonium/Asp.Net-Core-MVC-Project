using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Project_Client.Models
{
    public class SubCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
        public Guid CategoryId { get; set; }
    }
}
