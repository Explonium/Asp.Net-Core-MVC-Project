using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Project_Client.Models
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public Guid ChatMemberId { get; set; }
    }
}
