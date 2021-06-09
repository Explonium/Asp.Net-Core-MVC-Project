using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public Guid ChatMemberId { get; set; }

        // Relations

        [ForeignKey("ChatMemberId")]
        public virtual ChatMember ChatMember { get; set; }
    }
}
