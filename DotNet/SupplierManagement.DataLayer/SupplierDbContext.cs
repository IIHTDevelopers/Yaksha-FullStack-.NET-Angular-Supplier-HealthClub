using Microsoft.EntityFrameworkCore;
using SupplierManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierManagement.DataLayer
{
    public class SupplierDbContext : DbContext
    {
        public SupplierDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SupplierData> SupplierDatas { get; set; }
        public DbSet<ProductData> ProductDatas { get; set; }

    }
}
