using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Models
{
    public class PurchaseDetails
    {
        [Key]
        public int ID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        [ForeignKey("Purchase")]
        public int PurchaseId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Purchase Purchase { get; set; }
        public Product Product { get; set; }
    }
}
