using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities
{
    public class Chat
    {
        [Key]
        public Guid Id { get; set; }

        // Relations

        public ICollection<ChatMember> ChatMembers { get; set; } = new List<ChatMember>();
    }
}
