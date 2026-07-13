using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class CDMovementType
    {
        [Key]
        public int IdMovementType { get; set; }
        public string Description { get; set; }
        public char IsDelete { get; set; } = '0';
    }
}
