using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class Dispute
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ChatId { get; set; }
        public Guid DisputeReasonId { get; set; }
        public string Details { get; set; }

        // Relations

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [ForeignKey("ChatId")]
        public virtual Chat Chat { get; set; }

        [ForeignKey("DisputeReasonId")]
        public virtual DisputeReason DisputeReason { get; set; }
    }
}
