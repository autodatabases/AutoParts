using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoParts.Models
{
    public class Vehicle
    {
        [Key]
        [DisplayName("Vehicle Identification Number")]
        public string VIN { get; set; }

        [Required]
        [MaxLength(4, ErrorMessage = "Invalid Year")]
        [DisplayName("Build Year")]
        public string buildYear { get; set; }

        public int VendorId { get; set; }
        [ForeignKey("VendorId")]
        [ValidateNever]
        public Vendor Vendor { get; set; }
    }
}
