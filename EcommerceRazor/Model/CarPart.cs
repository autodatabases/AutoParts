using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EcommerceRazor.Model
{
    public class CarPart
    {
        [Key]
        public int PartId { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Car Manufacturer cannot be empty")]
        [DisplayName("Manufacturer")]
        public string Manufacturer { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Car Model cannot be empty")]
        [DisplayName("Model")]
        public string Model { get; set; }
        [Required]
        [StringLength(4, ErrorMessage = "Please enter a valid built year", MinimumLength = 4)]
        [DisplayName("Year")]
        public string Year { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Car Part Name cannot be empty")]
        [DisplayName("Part Name")]
        public string PartName { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Display Order must be 1-100")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
