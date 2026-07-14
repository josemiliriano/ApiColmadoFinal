using Application.Contract;
using Application.DTOs;
using Domain.Entities;
using Infraestructure.Data;
using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core
{
    public class InventoryMovementAppService : IInventoryMovementAppService
    {
        private readonly GeneralRepository<CDInventoryMovement> _movements;
        private readonly MyDataContext _context;
        public InventoryMovementAppService(GeneralRepository<CDInventoryMovement> movements, MyDataContext context)
        {
            _movements = movements;
            _context = context;
        }

        public CDInventoryMovement AddBuy(InventoryMovementDto Buy)
        {
            var product = _context.Products.FirstOrDefault(p => p.IdProduct == Buy.ProductId);
            if (product == null)
            {
                product = new CDProduct
                {
                    ProductName = Buy.ProductName,
                    Price = Buy.Price,
                    SalePrice = Buy.SalePrice,
                    Stock = Buy.Quantity,
                    CategoryId = Buy.CategoryId
                };

                _context.Products.Add(product);
                _context.SaveChanges();
            }
            else
            {
                product.Stock += Buy.Quantity;
            }
            var movement = new CDInventoryMovement
            {
                ProductId = product.IdProduct,
                MovementTypeiD = 1,
                Quantity = Buy.Quantity,
                Description = Buy.Description,
                ProviderId = Buy.ProviderId
            };
            _movements.Add(movement);

            return movement;
        }

        public CDInventoryMovement AddSale(InventoryMovementDto Sale)
        {
            var product = _context.Products.FirstOrDefault(p => p.IdProduct == Sale.ProductId);
            if (product == null)
            {
                throw new Exception("El producto no existe.");
            }
            if (product.Stock < Sale.Quantity)
            {
                throw new Exception("No hay suficiente stock para realizar la venta.");
            }
            product.Stock -= Sale.Quantity;
            var movement = new CDInventoryMovement
            {
                ProductId = Sale.ProductId,
                MovementTypeiD = 2,
                Quantity = Sale.Quantity,
                Description = Sale.Description,
                ProviderId = Sale.ProviderId
            };
            _movements.Add(movement);

            return movement;
        }

        public void DeleteTrasaction(int id)
        {
            var Transaction = _movements.GetById(id);
            if (Transaction == null)
            {
                throw new Exception($"El Id {id} no existe en la base de dattos");
            }
            _movements.Deleter(Transaction);
        }

        public List<CDInventoryMovement> GetAllBuy()
        {
            return _movements.GetAll().Where(b => b.MovementTypeiD == 1).ToList();
        }

        public List<CDInventoryMovement> GetAllSale()
        {
            return _movements.GetAll().Where(b => b.MovementTypeiD == 2).ToList();
        }

        public List<TrasactionCompleteDto> GetAllTransactionComplete()
        {
            var listTransaction = _context.Movements
         .Include(i => i.Product)
         .Include(i => i.Provider)
         .Include(i => i.MovementType)
         .Select(i => new TrasactionCompleteDto
         {
             ProductName = i.Product.ProductName,
             Quantity = i.Quantity,
             ProviderName = i.Provider != null ? i.Provider.ProviderName : "",
             DescriptionMovement = i.MovementType.Description
         })
         .ToList();

            return listTransaction;
        }

        public List<CDInventoryMovement> GetAllTransactionWihtCondition()
        {
            return _movements.GetAll().Where(i => i.IsDelete == '0').ToList();
        }

        public CDInventoryMovement GetById(int id)
        {
            return _movements.GetById(id);
        }

        public bool SoftDelete(int id)
        {
            var transaction = _movements.GetById(id);
            if (transaction == null)
            {
                throw new Exception($"El Id {id} no existe en la base de dattos");
            }
            transaction.IsDelete = '1';
            return true;
        }

        public CDInventoryMovement UpdateInventary(int id, InventoryMovementDto movement)
        {
            var mov = _movements.GetById(id);
            if (mov == null)
            {
                throw new Exception($"El Id {id} no existe en la base de dattos");
            }
            mov.ProductId = movement.ProductId;
            mov.MovementTypeiD = movement.MovementTypeiD;
            mov.Quantity = movement.Quantity;
            mov.Description = movement.Description;
            mov.ProviderId = movement.ProviderId;
            return _movements.Update(mov);
        }
    }
}
