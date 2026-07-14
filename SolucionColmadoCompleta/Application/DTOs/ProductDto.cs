using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class ProductDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
