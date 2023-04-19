using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BT_API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(250)'")]
        public string? Productname { get; set; }

        public string? Manufacturer { get; set; }

        public string? Description { get; set; }

        public string? Barcode { get; set; }

        public string? Co2 { get; set; }

        public int? Marking { get; set; }

        public string? Origin { get; set; }
       
    }
}
