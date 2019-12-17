using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseControl.Models
{

    // ItemName
    // Item Description
    // Price
    // Count
    public class ItemDetail
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string ItemName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ItemDescription { get; set; }
        [Required]
        [Range(0.01, 100000), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18)")]
        public decimal ItemPrice { get; set; }
        [Required]
        public int ItemCount { get; set; }
    }
}
