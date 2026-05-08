using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Data_Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role-sales");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role-warehouse");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "role-admin", "user-01" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role-admin");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-01");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ROLE-ADMIN-0001", "ROLE-ADMIN-STAMP", "Admin", "ADMIN" },
                    { "ROLE-SALES-0001", "ROLE-SALES-STAMP", "SalesEmployee", "SALESEMPLOYEE" },
                    { "ROLE-WARE-0001", "ROLE-WARE-STAMP", "WarehouseEmployee", "WAREHOUSEEMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "IsActive", "JobTitle", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "USER-ADMIN-0001", 0, "ADMIN-CONCURRENCY-STAMP", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@erp.com", true, "System Administrator", true, "System Admin", false, null, "ADMIN@ERP.COM", "ADMIN@ERP.COM", "AQAAAAIAAYagAAAAEFUfno0apiyLD/H8ltTclkliznkIZH6rI8yl1YGS1dU1uThxbTPavE4cAWJGQzVzQA==", null, false, "ADMIN-SECURITY-STAMP", false, "admin@erp.com" },
                    { "USER-SALES-0001", 0, "SALES-CONCURRENCY-STAMP", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "sarah.sales@erp.com", true, "Sarah Johnson", true, "Sales Representative", false, null, "SARAH.SALES@ERP.COM", "SARAH.SALES@ERP.COM", "AQAAAAIAAYagAAAAEAVnV/2QHL/X98hyikRM3G8yaVl6aDRp4DQgPcZklWl+0fSaDqUpfxYwIhC9Ru75Nw==", null, false, "SALES-SECURITY-STAMP", false, "sarah.sales@erp.com" },
                    { "USER-WARE-0001", 0, "WARE-CONCURRENCY-STAMP", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "mike.warehouse@erp.com", true, "Mike Thompson", true, "Warehouse Manager", false, null, "MIKE.WAREHOUSE@ERP.COM", "MIKE.WAREHOUSE@ERP.COM", "AQAAAAIAAYagAAAAEFyCBJ7rkekCduH/qr+5QFx4ffatRF1x6/ci9RnMQMnfVdDqhe7z0PoAJtiWIYarhQ==", null, false, "WARE-SECURITY-STAMP", false, "mike.warehouse@erp.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Electronic devices and accessories", "Electronics" },
                    { 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Stationery, paper, and office essentials", "Office Supplies" },
                    { 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Office and home furniture", "Furniture" },
                    { 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Networking hardware and cables", "Networking" },
                    { 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Software products and license keys", "Software & Licenses" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "12 Nile St, Cairo", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), "alice@example.com", "Alice Morgan", "01001234567" },
                    { 2, "45 Pyramids Ave, Giza", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), "bob@example.com", "Bob Carter", "01011234567" },
                    { 3, "7 Tahrir Sq, Cairo", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), "clara@example.com", "Clara Stone", "01021234567" },
                    { 4, "33 Corniche Rd, Alexandria", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), "david@example.com", "David Hale", "01031234567" },
                    { 5, "88 October City, Giza", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), "eva@example.com", "Eva Nguyen", "01041234567" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Industrial Zone A, Cairo", new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), "sales@techsource.com", "TechSource LLC", "01101234567" },
                    { 2, "Free Zone, Alexandria", new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), "orders@globaldepot.com", "Global Office Depot", "01111234567" },
                    { 3, "New Cairo, Cairo", new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), "info@furnipro.eg", "FurniPro Egypt", "01121234567" },
                    { 4, "Smart Village, Giza", new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), "support@netgearab.com", "NetGear Arabia", "01131234567" },
                    { 5, "Downtown, Cairo", new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), "licenses@softdist.com", "SoftDist International", "01141234567" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ROLE-ADMIN-0001", "USER-ADMIN-0001" },
                    { "ROLE-SALES-0001", "USER-SALES-0001" },
                    { "ROLE-WARE-0001", "USER-WARE-0001" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "CustomerId", "IsDeleted", "OrderDate", "PaidAmount", "PaymentStatus", "Status", "TotalAmount", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "USER-SALES-0001", 1, false, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1099.99m, "Paid", "Completed", 1099.99m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), "USER-SALES-0001", 2, false, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), 300.00m, "Partial", "Pending", 599.98m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), "USER-SALES-0001", 3, false, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), 0m, "Pending", "Pending", 399.99m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "USER-SALES-0001", 4, false, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), 179.99m, "Paid", "Completed", 179.99m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), "USER-SALES-0001", 5, false, new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc), 0m, "Pending", "Cancelled", 59.99m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CostPrice", "CreatedAt", "Image", "Name", "SKU", "SellingPrice", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, 750.00m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "dell-laptop.jpg", "Dell Laptop 15\"", "ELEC-001", 1099.99m, 50 },
                    { 2, 1, 180.00m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hp-monitor.jpg", "HP Monitor 24\"", "ELEC-002", 299.99m, 80 },
                    { 3, 3, 220.00m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "office-chair.jpg", "Ergonomic Office Chair", "FURN-001", 399.99m, 30 },
                    { 4, 4, 35.00m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tp-switch.jpg", "TP-Link 8-Port Switch", "NET-001", 59.99m, 60 },
                    { 5, 5, 100.00m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ms-office.jpg", "Microsoft Office 2024 Key", "SOFT-001", 179.99m, 100 }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "PurchaseDate", "Status", "SupplierId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "USER-WARE-0001", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Received", 1, 37500.00m },
                    { 2, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), "USER-WARE-0001", new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Received", 2, 9000.00m },
                    { 3, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "USER-WARE-0001", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Received", 3, 6600.00m },
                    { 4, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "USER-WARE-0001", new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "Received", 4, 2100.00m },
                    { 5, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), "USER-WARE-0001", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Pending", 5, 10000.00m }
                });

            migrationBuilder.InsertData(
                table: "InventoryLogs",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "OrderId", "ProductId", "PurchaseId", "Quantity", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "USER-WARE-0001", null, 1, 1, 50, "In" },
                    { 2, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), "USER-WARE-0001", null, 2, 2, 50, "In" },
                    { 3, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "USER-SALES-0001", 1, 1, null, -1, "Out" },
                    { 4, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), "USER-SALES-0001", 2, 2, null, -2, "Out" },
                    { 5, new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), "USER-WARE-0001", null, 3, null, -3, "Adjustment" }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1099.99m },
                    { 2, 2, 2, 2, 299.99m },
                    { 3, 3, 3, 1, 399.99m },
                    { 4, 4, 5, 1, 179.99m },
                    { 5, 5, 4, 1, 59.99m }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "CustomerId", "OrderId", "PaymentDate", "PaymentMethod" },
                values: new object[,]
                {
                    { 1, 1099.99m, 1, 1, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Card" },
                    { 2, 300.00m, 2, 2, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Cash" },
                    { 3, 150.00m, 2, 2, new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Transfer" },
                    { 4, 179.99m, 4, 4, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Card" },
                    { 5, 100.00m, 3, 3, new DateTime(2025, 2, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Cash" }
                });

            migrationBuilder.InsertData(
                table: "PurchaseItem",
                columns: new[] { "Id", "ProductId", "PurchaseId", "Quantity", "UnitCost" },
                values: new object[,]
                {
                    { 1, 1, 1, 50, 750.00m },
                    { 2, 2, 2, 50, 180.00m },
                    { 3, 3, 3, 30, 220.00m },
                    { 4, 4, 4, 60, 35.00m },
                    { 5, 5, 5, 100, 100.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ROLE-ADMIN-0001", "USER-ADMIN-0001" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ROLE-SALES-0001", "USER-SALES-0001" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ROLE-WARE-0001", "USER-WARE-0001" });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InventoryLogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InventoryLogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InventoryLogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InventoryLogs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "InventoryLogs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PurchaseItem",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PurchaseItem",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PurchaseItem",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PurchaseItem",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PurchaseItem",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ROLE-ADMIN-0001");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ROLE-SALES-0001");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ROLE-WARE-0001");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "USER-ADMIN-0001");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "USER-SALES-0001");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "USER-WARE-0001");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "role-admin", null, "Admin", "ADMIN" },
                    { "role-sales", null, "SalesEmployee", "SALESEMPLOYEE" },
                    { "role-warehouse", null, "WarehouseEmployee", "WAREHOUSEEMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "IsActive", "JobTitle", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "user-01", 0, "concurrency-stamp-user-01", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@erp.com", true, "Omar Hassan", true, "System Administrator", false, null, "ADMIN@ERP.COM", "ADMIN@ERP.COM", "AQAAAAIAAYagAAAAELpc4ee0rcN+gwDM+z+gsaOptutPB1r7lDh6F83T932RaZK0DazoYsT7XF4RQgpeKw==", null, false, "security-stamp-user-01", false, "admin@erp.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "role-admin", "user-01" });
        }
    }
}
