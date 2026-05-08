//using ERP.Domain.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ERP.Repositories.Repository
//{
//    public class UnitOfWork : IUnitOfWork
//    {
//        private readonly ERPDBContext _context;
//        public IGenericRepository<Product> Products { get; private set; }
//        public IGenericRepository<Category> Categories { get; private set; }
//        public IGenericRepository<Order> Orders { get; private set; }
//        public IGenericRepository<InventoryLog> InventoryLogs { get; private set; }
//        public UnitOfWork(ERPDBContext context, GenericRepository<Product> products, GenericRepository<Category> categories, GenericRepository<Order> orders, GenericRepository<InventoryLog> inventoryLogs)
//        {
//            _context = context;
//            Products = products;
//            Categories = categories;
//            Orders = orders;
//            InventoryLogs = inventoryLogs;
//        }
//        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

//        public void Dispose() => _context.Dispose();
//    }
//}
