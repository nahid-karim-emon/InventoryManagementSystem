using IMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Data
{
    public class ApplicationWriteDbContext : DbContext
    {
        public ApplicationWriteDbContext(DbContextOptions<ApplicationWriteDbContext> options) : base(options)
        {

        }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchageOrder> PurchageOrders { get; set; }
        public DbSet<SellerOrder> SellerOrders { get; set; }
        public DbSet<WarehouseStock > WarehouseStocks { get;set; }
        public DbSet<PurchaseOrderItem> PurchaseOrdersItem { get; set; }
        public DbSet<SellerOrderItem> SellerOrderItems { get; set; }
        public DbSet<WarehouseReceivedProduct> WarehouseReceivedProducts { get; set; }
    }

    public class ApplicationReadDbContext : DbContext
    {
        public ApplicationReadDbContext(DbContextOptions<ApplicationReadDbContext> options) : base(options)
        {

        }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchageOrder> PurchageOrders { get; set; }
        public DbSet<SellerOrder> SellerOrders { get; set; }
        public DbSet<WarehouseStock> WarehouseStocks { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrdersItem { get; set; }
        public DbSet<SellerOrderItem> SellerOrderItems { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new InvalidOperationException("This context is read-only.");
        }
    }
}
