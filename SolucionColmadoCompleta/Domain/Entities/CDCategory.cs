using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class CDCategory
    {
        [Key]
        public int IdCategory { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public char Isdelete { get; set; } = '0';
        public ICollection<CDProduct> Products { get; set; }
    }
}
