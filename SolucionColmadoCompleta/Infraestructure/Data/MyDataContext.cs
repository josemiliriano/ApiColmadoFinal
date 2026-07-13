using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data
{
    public class MyDataContext : DbContext
    {
        public MyDataContext(DbContextOptions<MyDataContext> options) : base(options)
        {

        }
        public DbSet<CDCategory> Categories { get; set; }
        public DbSet<CDProduct> Products { get; set; }
        public DbSet<CDProvider> Providers { get; set; }
        public DbSet<CDMovementType> MovementTypes { get; set; }
        public DbSet<CDInventoryMovement> Movements { get; set; }
    }
}
