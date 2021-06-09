using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApi.Entities
{
    public class DisputeReason
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        // Relations

        [InverseProperty("DisputeReason")]
        public virtual ICollection<Dispute> Disputes { get; set; }
    }
}
