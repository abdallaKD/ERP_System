using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Models
{
    public class InvenotoryLog
    {
        [Key]
        public int ID { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }

        [ForeignKey("employee")]
        public int EmpId { get; set; }
        [ForeignKey("product")]
        public int ProductId { get; set; }

        public Employee employee { get; set; }
        public Product product { get; set; }
    }
}
