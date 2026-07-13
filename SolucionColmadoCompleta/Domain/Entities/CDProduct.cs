using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class CDProduct
    {
        [Key]
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public CDCategory Category { get; set; }
        public char IsDelete { get; set; } = '0';
    }
}
