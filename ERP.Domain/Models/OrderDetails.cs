using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Models
{
    public class OrderDetails
    {
        [Key]
        public int ID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("order")]
        public int OrderId;
        [ForeignKey("product")]
        public int ProductId;

        public Order order { get; set; }
        public Product product { get; set; }
        
    }
}
