using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoParts.Models
{
    public class Vendor
    {
        [Key]
        [DisplayName("Vendor ID")]
        public int VendorId { get; set; }

        [Required]
        [DisplayName("Manufacturer")]
        public string Manufacturer { get; set; }

        [Required]
        [DisplayName("Model")]
        public string Model { get; set; }


    }
}