using ERP.Domain.Enums;
using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Services.InventoryService
{
    public interface IInventoryService
    {
        // تعديل المخزن (إضافة/سحب/تسوية)
        Task<bool> AdjustStockAsync(int productId, int quantity, InventoryMovementType type, string userId, int? orderId = null, int? purchaseId = null, string? notes = null);

        // التحقق من توافر كمية معينة قبل البيع
        Task<bool> IsStockAvailableAsync(int productId, int requestedQuantity);

        // الحصول على المنتجات التي وصلت لـ Reorder Level
        Task<IEnumerable<Product>> GetLowStockProductsAsync();
    }
}
