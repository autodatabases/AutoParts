using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
    }
}
