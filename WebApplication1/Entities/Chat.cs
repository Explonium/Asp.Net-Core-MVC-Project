using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class Chat
    {
        [Key]
        public Guid Id { get; set; }

        // Relations

        [InverseProperty("Chat")]
        public virtual ICollection<ChatMember> ChatMembers { get; set; }
    }
}
