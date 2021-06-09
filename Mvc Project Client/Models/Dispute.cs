using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_Project_Client.Models
{
    public class Dispute
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ChatId { get; set; }
        public Guid DisputeReasonId { get; set; }
        public string Details { get; set; }
    }
}
