using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        public string Gender { get; set; }

        public List<Order>? Orders { get; set; } = new List<Order>();
        public List<Purchase>? Purchases { get; set; } = new List<Purchase>();
        public List<InvenotoryLog>? invenotoryLogs { get; set; } = new List<InvenotoryLog>();
    }
}
