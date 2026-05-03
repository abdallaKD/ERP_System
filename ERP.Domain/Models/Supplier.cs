using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Models
{
    public class Supplier
    {
        [Key]
        public int ID { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string ContactName { get; set; }

        public List<Purchase>? Purchases { get; set; } = new List<Purchase>();
    }
}
