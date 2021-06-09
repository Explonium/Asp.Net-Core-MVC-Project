using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities
{
    public class Dispute
    {
        [Key]
        public Guid Id { get; set; }
    }
}
