using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract
{
    public interface IProductAppServices
    {
        public CDProduct AddProduct(ProductDto dto);
        public List<CDProduct> GetAllProducts();
        public CDProduct GetProductById(int id);
        public CDProduct UpdateProduct(int id, ProductDto dto);
        public void DeleteProduct(int id);
        public bool SoftDelete(int id);
        public List<CDProduct> GetProductNoDeleted();
        public List<ProductCompleteDto> GetAllProductWihtCategory();
    }
}
