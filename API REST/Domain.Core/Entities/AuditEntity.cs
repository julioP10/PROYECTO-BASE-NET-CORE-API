using System;

namespace Domain.Core.Entities
{
    public class AuditEntity<TId> : Entity<TId>
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}