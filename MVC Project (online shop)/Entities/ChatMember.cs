using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    public class ChatMember
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public Guid ChatId { get; set; }
        public string ChatName { get; set; }

        [ForeignKey("Username")]
        public User User { get; set; }

        [ForeignKey("ChatId")]
        public Chat Chat { get; set; }
    }
}
