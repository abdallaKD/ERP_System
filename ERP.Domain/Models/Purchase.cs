using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Models
{
    public class Purchase
    {
        [Key]
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int TotalAmount { get; set; }

        [ForeignKey("employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("supplier")]
        public int SupplierId { get; set; }
        public Employee employee { get; set; }
        public Supplier supplier { get; set; }
        public List<PurchaseDetails>? purchaseDetails { get; set; } = new List<PurchaseDetails>();
    }
}
