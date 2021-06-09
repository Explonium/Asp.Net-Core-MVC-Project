using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Project_Client.Models
{
    public class ChatMember
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public Guid ChatId { get; set; }
        public string ChatName { get; set; }
    }
}
