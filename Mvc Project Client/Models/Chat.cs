using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Project_Client.Models
{
    public class Chat
    {
        [Key]
        public Guid Id { get; set; }
    }
}
