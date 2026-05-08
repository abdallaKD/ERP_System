using ERP.Domain.Enums;
using ERP.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Repositories
{
    public class ERPDBContext : IdentityDbContext<ApplicationUser>
    {
        public ERPDBContext(DbContextOptions<ERPDBContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItem { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<InventoryLog> InventoryLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ── Fluent config
            builder.Entity<Order>()
                .Ignore(o => o.RemainingAmount);

            builder.Entity<OrderItem>()
                .Ignore(oi => oi.TotalPrice);

            builder.Entity<PurchaseItem>()
                .Ignore(pi => pi.TotalCost);

            builder.Entity<Order>()
                .Property(o => o.Status)
                .HasConversion<string>();

            builder.Entity<Order>()
                .Property(o => o.PaymentStatus)
                .HasConversion<string>();

            builder.Entity<Purchase>()
                .Property(p => p.Status)
                .HasConversion<string>();

            builder.Entity<Payment>()
                .Property(p => p.PaymentMethod)
                .HasConversion<string>();

            builder.Entity<InventoryLog>()
                .Property(il => il.Type)
                .HasConversion<string>();

            // ── Relationship: Order → Customer 
            builder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            // ── Relationship: Payment → Order 
            builder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithMany(o => o.Payments)
                .HasForeignKey(p => p.OrderId);

            // ── Relationship: Order → ApplicationUser 
            builder.Entity<Order>()
                .HasOne(o => o.CreatedByUser)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.CreatedByUserId);

            // ── Relationship: Purchase → ApplicationUser 
            builder.Entity<Purchase>()
                .HasOne(p => p.CreatedByUser)
                .WithMany(u => u.Purchases)
                .HasForeignKey(p => p.CreatedByUserId);

            // ── Relationship: InventoryLog → ApplicationUser 
            builder.Entity<InventoryLog>()
                .HasOne(il => il.CreatedByUser)
                .WithMany(u => u.InventoryLogs)
                .HasForeignKey(il => il.CreatedByUserId);

            // ═════════════════════════════════════════════════════════════════
            //  DATA SEEDING
            // ═════════════════════════════════════════════════════════════════

            SeedRoles(builder);
            SeedUsers(builder);
            SeedCategories(builder);
            SeedProducts(builder);
            SeedCustomers(builder);
            SeedSuppliers(builder);
            SeedPurchases(builder);
            SeedPurchaseItems(builder);
            SeedOrders(builder);
            SeedOrderItems(builder);
            SeedPayments(builder);
            SeedInventoryLogs(builder);
        }

        // =====================================================================
        // ROLES
        // =====================================================================
        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "ROLE-ADMIN-0001",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "ROLE-ADMIN-STAMP"
                },
                new IdentityRole
                {
                    Id = "ROLE-SALES-0001",
                    Name = "SalesEmployee",
                    NormalizedName = "SALESEMPLOYEE",
                    ConcurrencyStamp = "ROLE-SALES-STAMP"
                },
                new IdentityRole
                {
                    Id = "ROLE-WARE-0001",
                    Name = "WarehouseEmployee",
                    NormalizedName = "WAREHOUSEEMPLOYEE",
                    ConcurrencyStamp = "ROLE-WARE-STAMP"
                }
            );
        }

        // =====================================================================
        // USERS  (1 Admin · 1 SalesEmployee · 1 WarehouseEmployee)
        // =====================================================================
        private static void SeedUsers(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            // ── Admin 
            var admin = new ApplicationUser
            {
                Id = "USER-ADMIN-0001",
                UserName = "admin@erp.com",
                NormalizedUserName = "ADMIN@ERP.COM",
                Email = "admin@erp.com",
                NormalizedEmail = "ADMIN@ERP.COM",
                EmailConfirmed = true,
                FullName = "System Administrator",
                JobTitle = "System Admin",
                IsActive = true,
                CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                SecurityStamp = "ADMIN-SECURITY-STAMP",
                ConcurrencyStamp = "ADMIN-CONCURRENCY-STAMP",
                PasswordHash = "AQAAAAIAAYagAAAAEFUfno0apiyLD/H8ltTclkliznkIZH6rI8yl1YGS1dU1uThxbTPavE4cAWJGQzVzQA=="
            };
            //admin.PasswordHash = hasher.HashPassword(admin, "Admin@123456");

            // ── Sales Employee 
            var salesUser = new ApplicationUser
            {
                Id = "USER-SALES-0001",
                UserName = "sarah.sales@erp.com",
                NormalizedUserName = "SARAH.SALES@ERP.COM",
                Email = "sarah.sales@erp.com",
                NormalizedEmail = "SARAH.SALES@ERP.COM",
                EmailConfirmed = true,
                FullName = "Sarah Johnson",
                JobTitle = "Sales Representative",
                IsActive = true,
                CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                SecurityStamp = "SALES-SECURITY-STAMP",
                ConcurrencyStamp = "SALES-CONCURRENCY-STAMP",
                PasswordHash = "AQAAAAIAAYagAAAAEAVnV/2QHL/X98hyikRM3G8yaVl6aDRp4DQgPcZklWl+0fSaDqUpfxYwIhC9Ru75Nw=="
            };
            //salesUser.PasswordHash = hasher.HashPassword(salesUser, "Sales@123456");

            // ── Warehouse Employee 
            var warehouseUser = new ApplicationUser
            {
                Id = "USER-WARE-0001",
                UserName = "mike.warehouse@erp.com",
                NormalizedUserName = "MIKE.WAREHOUSE@ERP.COM",
                Email = "mike.warehouse@erp.com",
                NormalizedEmail = "MIKE.WAREHOUSE@ERP.COM",
                EmailConfirmed = true,
                FullName = "Mike Thompson",
                JobTitle = "Warehouse Manager",
                IsActive = true,
                CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                SecurityStamp = "WARE-SECURITY-STAMP",
                ConcurrencyStamp = "WARE-CONCURRENCY-STAMP",
                PasswordHash = "AQAAAAIAAYagAAAAEFyCBJ7rkekCduH/qr+5QFx4ffatRF1x6/ci9RnMQMnfVdDqhe7z0PoAJtiWIYarhQ=="
            };
            //warehouseUser.PasswordHash = hasher.HashPassword(warehouseUser, "Warehouse@123456");

            builder.Entity<ApplicationUser>().HasData(admin, salesUser, warehouseUser);

            // ── User → Role mapping 
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "USER-ADMIN-0001", RoleId = "ROLE-ADMIN-0001" },
                new IdentityUserRole<string> { UserId = "USER-SALES-0001", RoleId = "ROLE-SALES-0001" },
                new IdentityUserRole<string> { UserId = "USER-WARE-0001", RoleId = "ROLE-WARE-0001" }
            );
        }

        // =====================================================================
        // CATEGORIES  (5 rows)
        // =====================================================================
        private static void SeedCategories(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Electronic devices and accessories", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Category { Id = 2, Name = "Office Supplies", Description = "Stationery, paper, and office essentials", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Category { Id = 3, Name = "Furniture", Description = "Office and home furniture", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Category { Id = 4, Name = "Networking", Description = "Networking hardware and cables", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Category { Id = 5, Name = "Software & Licenses", Description = "Software products and license keys", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
            );
        }

        // =====================================================================
        // PRODUCTS  (5 rows)
        // =====================================================================
        private static void SeedProducts(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Dell Laptop 15\"", SKU = "ELEC-001", CostPrice = 750.00m, SellingPrice = 1099.99m, StockQuantity = 50, CategoryId = 1, Image = "dell-laptop.jpg", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Product { Id = 2, Name = "HP Monitor 24\"", SKU = "ELEC-002", CostPrice = 180.00m, SellingPrice = 299.99m, StockQuantity = 80, CategoryId = 1, Image = "hp-monitor.jpg", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Product { Id = 3, Name = "Ergonomic Office Chair", SKU = "FURN-001", CostPrice = 220.00m, SellingPrice = 399.99m, StockQuantity = 30, CategoryId = 3, Image = "office-chair.jpg", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Product { Id = 4, Name = "TP-Link 8-Port Switch", SKU = "NET-001", CostPrice = 35.00m, SellingPrice = 59.99m, StockQuantity = 60, CategoryId = 4, Image = "tp-switch.jpg", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Product { Id = 5, Name = "Microsoft Office 2024 Key", SKU = "SOFT-001", CostPrice = 100.00m, SellingPrice = 179.99m, StockQuantity = 100, CategoryId = 5, Image = "ms-office.jpg", CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
            );
        }

        // =====================================================================
        // CUSTOMERS  (5 rows)
        // =====================================================================
        private static void SeedCustomers(ModelBuilder builder)
        {
            builder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Alice Morgan", Phone = "01001234567", Email = "alice@example.com", Address = "12 Nile St, Cairo", CreatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                new Customer { Id = 2, Name = "Bob Carter", Phone = "01011234567", Email = "bob@example.com", Address = "45 Pyramids Ave, Giza", CreatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                new Customer { Id = 3, Name = "Clara Stone", Phone = "01021234567", Email = "clara@example.com", Address = "7 Tahrir Sq, Cairo", CreatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                new Customer { Id = 4, Name = "David Hale", Phone = "01031234567", Email = "david@example.com", Address = "33 Corniche Rd, Alexandria", CreatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                new Customer { Id = 5, Name = "Eva Nguyen", Phone = "01041234567", Email = "eva@example.com", Address = "88 October City, Giza", CreatedAt = new DateTime(2025, 1, 5, 0, 0, 0, DateTimeKind.Utc) }
            );
        }

        // =====================================================================
        // SUPPLIERS  (5 rows)
        // =====================================================================
        private static void SeedSuppliers(ModelBuilder builder)
        {
            builder.Entity<Supplier>().HasData(
                new Supplier { Id = 1, Name = "TechSource LLC", Phone = "01101234567", Email = "sales@techsource.com", Address = "Industrial Zone A, Cairo", CreatedAt = new DateTime(2025, 1, 3, 0, 0, 0, DateTimeKind.Utc) },
                new Supplier { Id = 2, Name = "Global Office Depot", Phone = "01111234567", Email = "orders@globaldepot.com", Address = "Free Zone, Alexandria", CreatedAt = new DateTime(2025, 1, 3, 0, 0, 0, DateTimeKind.Utc) },
                new Supplier { Id = 3, Name = "FurniPro Egypt", Phone = "01121234567", Email = "info@furnipro.eg", Address = "New Cairo, Cairo", CreatedAt = new DateTime(2025, 1, 3, 0, 0, 0, DateTimeKind.Utc) },
                new Supplier { Id = 4, Name = "NetGear Arabia", Phone = "01131234567", Email = "support@netgearab.com", Address = "Smart Village, Giza", CreatedAt = new DateTime(2025, 1, 3, 0, 0, 0, DateTimeKind.Utc) },
                new Supplier { Id = 5, Name = "SoftDist International", Phone = "01141234567", Email = "licenses@softdist.com", Address = "Downtown, Cairo", CreatedAt = new DateTime(2025, 1, 3, 0, 0, 0, DateTimeKind.Utc) }
            );
        }

        // =====================================================================
        // PURCHASES  (5 rows)
        // =====================================================================
        private static void SeedPurchases(ModelBuilder builder)
        {
            builder.Entity<Purchase>().HasData(
                new Purchase { Id = 1, SupplierId = 1, CreatedByUserId = "USER-WARE-0001", PurchaseDate = new DateTime(2025, 1, 10, 0, 0, 0, DateTimeKind.Utc), TotalAmount = 37500.00m, Status = PurchaseStatus.Received, CreatedAt = new DateTime(2025, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                new Purchase { Id = 2, SupplierId = 2, CreatedByUserId = "USER-WARE-0001", PurchaseDate = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc), TotalAmount = 9000.00m, Status = PurchaseStatus.Received, CreatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc) },
                new Purchase { Id = 3, SupplierId = 3, CreatedByUserId = "USER-WARE-0001", PurchaseDate = new DateTime(2025, 1, 15, 0, 0, 0, DateTimeKind.Utc), TotalAmount = 6600.00m, Status = PurchaseStatus.Received, CreatedAt = new DateTime(2025, 1, 15, 0, 0, 0, DateTimeKind.Utc) },
                new Purchase { Id = 4, SupplierId = 4, CreatedByUserId = "USER-WARE-0001", PurchaseDate = new DateTime(2025, 1, 18, 0, 0, 0, DateTimeKind.Utc), TotalAmount = 2100.00m, Status = PurchaseStatus.Received, CreatedAt = new DateTime(2025, 1, 18, 0, 0, 0, DateTimeKind.Utc) },
                new Purchase { Id = 5, SupplierId = 5, CreatedByUserId = "USER-WARE-0001", PurchaseDate = new DateTime(2025, 1, 20, 0, 0, 0, DateTimeKind.Utc), TotalAmount = 10000.00m, Status = PurchaseStatus.Pending, CreatedAt = new DateTime(2025, 1, 20, 0, 0, 0, DateTimeKind.Utc) }
            );
        }

        // =====================================================================
        // PURCHASE ITEMS  (5 rows — one per purchase)
        // =====================================================================
        private static void SeedPurchaseItems(ModelBuilder builder)
        {
            builder.Entity<PurchaseItem>().HasData(
                new PurchaseItem { Id = 1, PurchaseId = 1, ProductId = 1, Quantity = 50, UnitCost = 750.00m },  // 50 × 750  = 37,500
                new PurchaseItem { Id = 2, PurchaseId = 2, ProductId = 2, Quantity = 50, UnitCost = 180.00m },  // 50 × 180  =  9,000
                new PurchaseItem { Id = 3, PurchaseId = 3, ProductId = 3, Quantity = 30, UnitCost = 220.00m },  // 30 × 220  =  6,600
                new PurchaseItem { Id = 4, PurchaseId = 4, ProductId = 4, Quantity = 60, UnitCost = 35.00m },  // 60 × 35   =  2,100
                new PurchaseItem { Id = 5, PurchaseId = 5, ProductId = 5, Quantity = 100, UnitCost = 100.00m }   // 100 × 100 = 10,000
            );
        }

        // =====================================================================
        // ORDERS  (5 rows)
        // =====================================================================
        private static void SeedOrders(ModelBuilder builder)
        {
            builder.Entity<Order>().HasData(
                // Order 1 — Fully paid
                new Order
                {
                    Id = 1,
                    CustomerId = 1,
                    CreatedByUserId = "USER-SALES-0001",
                    OrderDate = new DateTime(2025, 2, 1, 0, 0, 0, DateTimeKind.Utc),
                    TotalAmount = 1099.99m,
                    PaidAmount = 1099.99m,
                    Status = OrderStatus.Completed,
                    PaymentStatus = PaymentStatus.Paid,
                    CreatedAt = new DateTime(2025, 2, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                // Order 2 — Partial payment
                new Order
                {
                    Id = 2,
                    CustomerId = 2,
                    CreatedByUserId = "USER-SALES-0001",
                    OrderDate = new DateTime(2025, 2, 5, 0, 0, 0, DateTimeKind.Utc),
                    TotalAmount = 599.98m,
                    PaidAmount = 300.00m,
                    Status = OrderStatus.Pending,
                    PaymentStatus = PaymentStatus.Partial,
                    CreatedAt = new DateTime(2025, 2, 5, 0, 0, 0, DateTimeKind.Utc)
                },
                // Order 3 — Unpaid
                new Order
                {
                    Id = 3,
                    CustomerId = 3,
                    CreatedByUserId = "USER-SALES-0001",
                    OrderDate = new DateTime(2025, 2, 10, 0, 0, 0, DateTimeKind.Utc),
                    TotalAmount = 399.99m,
                    PaidAmount = 0,
                    Status = OrderStatus.Pending,
                    PaymentStatus = PaymentStatus.Pending,
                    CreatedAt = new DateTime(2025, 2, 10, 0, 0, 0, DateTimeKind.Utc)
                },
                // Order 4 — Completed and fully paid
                new Order
                {
                    Id = 4,
                    CustomerId = 4,
                    CreatedByUserId = "USER-SALES-0001",
                    OrderDate = new DateTime(2025, 2, 14, 0, 0, 0, DateTimeKind.Utc),
                    TotalAmount = 179.99m,
                    PaidAmount = 179.99m,
                    Status = OrderStatus.Completed,
                    PaymentStatus = PaymentStatus.Paid,
                    CreatedAt = new DateTime(2025, 2, 14, 0, 0, 0, DateTimeKind.Utc)
                },
                // Order 5 — Cancelled
                new Order
                {
                    Id = 5,
                    CustomerId = 5,
                    CreatedByUserId = "USER-SALES-0001",
                    OrderDate = new DateTime(2025, 2, 18, 0, 0, 0, DateTimeKind.Utc),
                    TotalAmount = 59.99m,
                    PaidAmount = 0,
                    Status = OrderStatus.Cancelled,
                    PaymentStatus = PaymentStatus.Pending,
                    CreatedAt = new DateTime(2025, 2, 18, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }

        // =====================================================================
        // ORDER ITEMS  (5 rows — one per order)
        // =====================================================================
        private static void SeedOrderItems(ModelBuilder builder)
        {
            builder.Entity<OrderItem>().HasData(
                new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 1099.99m },  // Dell Laptop
                new OrderItem { Id = 2, OrderId = 2, ProductId = 2, Quantity = 2, UnitPrice = 299.99m },  // 2× HP Monitor
                new OrderItem { Id = 3, OrderId = 3, ProductId = 3, Quantity = 1, UnitPrice = 399.99m },  // Office Chair
                new OrderItem { Id = 4, OrderId = 4, ProductId = 5, Quantity = 1, UnitPrice = 179.99m },  // MS Office Key
                new OrderItem { Id = 5, OrderId = 5, ProductId = 4, Quantity = 1, UnitPrice = 59.99m }   // TP-Link Switch
            );
        }

        // =====================================================================
        // PAYMENTS  (5 rows)
        // =====================================================================
        private static void SeedPayments(ModelBuilder builder)
        {
            builder.Entity<Payment>().HasData(
                // Full payment for Order 1
                new Payment { Id = 1, OrderId = 1, CustomerId = 1, Amount = 1099.99m, PaymentDate = new DateTime(2025, 2, 1, 0, 0, 0, DateTimeKind.Utc), PaymentMethod = PaymentMethod.Card },
                // Partial payment for Order 2
                new Payment { Id = 2, OrderId = 2, CustomerId = 2, Amount = 300.00m, PaymentDate = new DateTime(2025, 2, 5, 0, 0, 0, DateTimeKind.Utc), PaymentMethod = PaymentMethod.Cash },
                // No payment for Order 3 — so no row here; instead seed an unrelated second payment for Order 2 showing multi-payment support:
                new Payment { Id = 3, OrderId = 2, CustomerId = 2, Amount = 150.00m, PaymentDate = new DateTime(2025, 2, 7, 0, 0, 0, DateTimeKind.Utc), PaymentMethod = PaymentMethod.Transfer },
                // Full payment for Order 4
                new Payment { Id = 4, OrderId = 4, CustomerId = 4, Amount = 179.99m, PaymentDate = new DateTime(2025, 2, 14, 0, 0, 0, DateTimeKind.Utc), PaymentMethod = PaymentMethod.Card },
                // Partial advance for Order 3
                new Payment { Id = 5, OrderId = 3, CustomerId = 3, Amount = 100.00m, PaymentDate = new DateTime(2025, 2, 11, 0, 0, 0, DateTimeKind.Utc), PaymentMethod = PaymentMethod.Cash }
            );
        }

        // =====================================================================
        // INVENTORY LOGS  (5 rows)
        // =====================================================================
        private static void SeedInventoryLogs(ModelBuilder builder)
        {
            builder.Entity<InventoryLog>().HasData(
                // IN — from Purchase 1 (50 Dell Laptops received)
                new InventoryLog { Id = 1, ProductId = 1, Quantity = 50, Type = InventoryMovementType.In, PurchaseId = 1, OrderId = null, CreatedByUserId = "USER-WARE-0001", CreatedAt = new DateTime(2025, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                // IN — from Purchase 2 (50 HP Monitors received)
                new InventoryLog { Id = 2, ProductId = 2, Quantity = 50, Type = InventoryMovementType.In, PurchaseId = 2, OrderId = null, CreatedByUserId = "USER-WARE-0001", CreatedAt = new DateTime(2025, 1, 12, 0, 0, 0, DateTimeKind.Utc) },
                // OUT — from Order 1 (1 Dell Laptop sold)
                new InventoryLog { Id = 3, ProductId = 1, Quantity = -1, Type = InventoryMovementType.Out, PurchaseId = null, OrderId = 1, CreatedByUserId = "USER-SALES-0001", CreatedAt = new DateTime(2025, 2, 1, 0, 0, 0, DateTimeKind.Utc) },
                // OUT — from Order 2 (2 HP Monitors sold)
                new InventoryLog { Id = 4, ProductId = 2, Quantity = -2, Type = InventoryMovementType.Out, PurchaseId = null, OrderId = 2, CreatedByUserId = "USER-SALES-0001", CreatedAt = new DateTime(2025, 2, 5, 0, 0, 0, DateTimeKind.Utc) },
                // ADJUSTMENT — manual stock correction on Office Chairs
                new InventoryLog { Id = 5, ProductId = 3, Quantity = -3, Type = InventoryMovementType.Adjustment, PurchaseId = null, OrderId = null, CreatedByUserId = "USER-WARE-0001", CreatedAt = new DateTime(2025, 2, 20, 0, 0, 0, DateTimeKind.Utc) }
            );
        }

        // ── UpdatedAt auto-stamp 
        public override int SaveChanges()
        {
            StampUpdatedAt();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            StampUpdatedAt();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void StampUpdatedAt()
        {
            foreach (var entry in ChangeTracker.Entries<Order>()
                         .Where(e => e.State is EntityState.Added or EntityState.Modified))
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
 }
