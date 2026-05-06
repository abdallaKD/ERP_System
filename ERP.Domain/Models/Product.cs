using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Product Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Display(Name = "SKU")]
        public string SKU { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Cost price must be zero or greater.")]
        [Display(Name = "Cost Price")]
        public decimal CostPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Selling price must be zero or greater.")]
        [Display(Name = "Selling Price")]
        public decimal SellingPrice { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties

        [ForeignKey(nameof(Category))]
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

        public virtual ICollection<PurchaseDetails> PurchaseDetails { get; set; } = new List<PurchaseDetails>();

        public virtual ICollection<InventoryLog> InventoryLogs { get; set; } = new List<InventoryLog>();
    }

}
