using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Project_Client.Models
{
    public class Deliverer
    {
        [Key]
        public string Username { get; set; }
    }
}
