using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Project_Client.Models
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
    }
}
