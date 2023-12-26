using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoParts.Models
{
    public class Vehicle
    {
        [Key]
        [DisplayName("Vehicle Id")]
        public int VehicleId { get; set; }

        [Required]
        [DisplayName("Vehicle Identification NUmber")]
        [MaxLength(4, ErrorMessage = "Invalid VIN")]
        public string VIN { get; set; }

        [Required]
        [DisplayName("Vehicle Manufacturer")]
        public string Manufacturer { get; set; }

        [Required]
        [DisplayName("Vehicle Model")]
        public string Model { get; set; }

        [Required]
        [DisplayName("Build Year")]
        public string BuildYear { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
