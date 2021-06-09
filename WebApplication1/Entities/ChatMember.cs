using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class ChatMember
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public Guid ChatId { get; set; }
        public string ChatName { get; set; }

        // Relations

        [ForeignKey("Username")]
        public virtual User User { get; set; }

        [ForeignKey("ChatId")]
        public virtual Chat Chat { get; set; }

        [InverseProperty("ChatMember")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}
