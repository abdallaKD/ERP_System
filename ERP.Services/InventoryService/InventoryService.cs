using ERP.Domain.Enums;
using ERP.Domain.Models;
using ERP.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Services.InventoryService
{
    public class InventoryService : IInventoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InventoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AdjustStockAsync(int productId, int quantity, InventoryMovementType type, string userId, int? orderId = null, int? purchaseId = null, string? notes = null)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productId);
            if (product == null) return false;

            // 1. تحديث الكمية في جدول الـ Product
            // الكمية (quantity) بتبعت موجبة في التوريد وسالبة في البيع
            product.StockQuantity += quantity;

            // 2. إنشاء سجل في الـ InventoryLog
            var log = new InventoryLog
            {
                ProductId = productId,
                Quantity = quantity,
                Type = type,
                CreatedByUserId = userId,
                OrderId = orderId,
                PurchaseId = purchaseId,
                //Notes = notes,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.InventoryLogs.AddAsync(log);

            // ملاحظة: مش هنعمل SaveChanges هنا.. الـ Unit of Work هو اللي هيعملها في الآخر
            return true;
        }

        public async Task<bool> IsStockAvailableAsync(int productId, int requestedQuantity)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productId);
            return product != null && product.StockQuantity >= requestedQuantity;
        }

        public async Task<IEnumerable<Product>> GetLowStockProductsAsync()
        {
            return await _unitOfWork.Products.FindAsync(p => p.StockQuantity <= p.ReorderLevel);
        }
    }
}
