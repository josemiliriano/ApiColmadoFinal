using Application.Contract;
using Application.DTOs;
using Domain.Entities;
using Infraestructure.Data;
using Infraestructure.Eceptions;
using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core
{
    public class ProductAppServices : IProductAppServices
    {
        private readonly GeneralRepository<CDProduct> _repository;
        private readonly MyDataContext _context;
        public ProductAppServices(GeneralRepository<CDProduct> repository, MyDataContext context)
        {
            _repository = repository;
            _context = context;
        }
        public CDProduct AddProduct(ProductDto dto)
        {
            try
            {
                var exist = _repository.Exists(p => p.ProductName.ToLower() == dto.ProductName.ToLower());
                if (exist)
                {
                    throw new AlreadyExistsException("Categoría", dto.ProductName);
                }
                var NewProduct = new CDProduct
                {
                    ProductName = dto.ProductName,
                    Price = dto.Price,
                    SalePrice = dto.SalePrice,
                    Stock = dto.Stock,
                    CategoryId = dto.CategoryId
                };
                return NewProduct;
            }
            catch (AlreadyExistsException e)
            {
                throw new(e.Message);
            }
        }

        public void DeleteProduct(int id)
        {
            var product = _repository.GetById(id);
            if (product != null)
            {
                _repository.Deleter(product);
            }
        }

        public List<CDProduct> GetAllProducts()
        {
            return _repository.GetAll();
        }

        public CDProduct GetProductById(int id)
        {
            return _repository.GetById(id);
        }

        public List<CDProduct> GetProductNoDeleted()
        {
            var ListProductNotDeleted = _repository.GetAll().Where(p => p.IsDelete == '0').ToList();
            return ListProductNotDeleted;
        }

        public bool SoftDelete(int id)
        {
            var product = _repository.GetById(id);
            if (product == null)
            {
                return false;
            }
            product.IsDelete = '1';
            return true;
        }

        public CDProduct UpdateProduct(int id, ProductDto dto)
        {
            var product = _repository.GetById(id);
            if (product != null)
            {
                product.ProductName = dto.ProductName;
                product.SalePrice = dto.SalePrice;
                product.Price = dto.Price;
                product.Stock = dto.Stock;
                product.CategoryId = dto.CategoryId;
            }
            return product;
        }

        public List<ProductCompleteDto> GetAllProductWihtCategory()
        {
            var listProducts = _context.Products.Include(p => p.Category).Select(p => new ProductCompleteDto
            {
                ProductName = p.ProductName,
                Price = p.Price,
                SalePrice = p.SalePrice,
                Stock = p.Stock,
                CategoryName = p.Category.CategoryName
            }).ToList();
            return listProducts;
        }

    }
}
