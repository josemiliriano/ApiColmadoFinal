using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class CDInventoryMovement
    {
        [Key]
        public int IdInventoryMovement { get; set; }
        public int ProductId { get; set; }
        public CDProduct Product { get; set; }
        public int MovementTypeiD { get; set; }
        public CDMovementType MovementType { get; set; }
        public int Quantity { get; set; }
        public DateTime MovementDate { get; set; } = DateTime.Now;
        public string? Description { get; set; }
        public int? ProviderId { get; set; }
        public CDProvider? Provider { get; set; }
        public char IsDelete { get; set; } = '0';
    }
}
