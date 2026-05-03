using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; } 
        public decimal PurchasePrice { get; set; }
        public decimal SalesPrice { get; set; }
        public int StockQuantity { get; set; }

        public List<PurchaseDetails>? purchaseDetails { get; set; } = new List<PurchaseDetails>();
        public List<OrderDetails>? orderDetails { get; set; } = new List<OrderDetails>();
        public List<InvenotoryLog>? invenotoryLogs { get; set; } = new List<InvenotoryLog>();

    }
}
