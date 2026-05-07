using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Repositories.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ERPDBContext _context;
        public IGenericRepository<Product> Products { get; private set; }
        public IGenericRepository<Category> Categories { get; private set; }
        public IGenericRepository<Order> Orders { get; private set; }
        public IGenericRepository<InventoryLog> InventoryLogs { get; private set; }


        public UnitOfWork(ERPDBContext context)
        {
            _context = context;
            Products = new GenericRepository<Product>(_context);
            Categories = new GenericRepository<Category>(_context);
            Orders = new GenericRepository<Order>(_context);
            InventoryLogs = new GenericRepository<InventoryLog>(_context);
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
