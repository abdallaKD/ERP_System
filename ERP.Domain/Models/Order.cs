using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderNumber { get; set; }
        public decimal TotalAmount { get; set; }

        [ForeignKey("employee")]
        public int EmpId { get; set; }
        [ForeignKey("customer")]
        public int CustomerId { get; set; }

        public Employee? employee { get; set; }
        public Customer? customer { get; set; }

        public List<OrderDetails> orderDetails { get; set; } = new List<OrderDetails>();

    }
}
