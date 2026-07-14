using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class InventoryMovementDto
    {
        public int ProductId { get; set; }
        public int MovementTypeiD { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public int? ProviderId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }

    }
}
