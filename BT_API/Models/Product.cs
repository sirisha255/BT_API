using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BT_API.Models
{
    public class Product
    {
        [Key]
        public int Index { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(250)'")]
        public string? Product_Name { get; set; }

        public string? Manufacturer { get; set; }

        public string? Description { get; set; }

        public string? BarCode { get; set; }

        public string? CO2 { get; set; }

        public int? Mark1 { get; set; }

        public string? Origin { get; set; }

    }
}
