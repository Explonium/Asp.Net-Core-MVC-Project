using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }
    }
}
