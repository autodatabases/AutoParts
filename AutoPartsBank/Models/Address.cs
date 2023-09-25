using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoPartsBank.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [DisplayName("Street")]
        [Required]
        public string Street { get; set; }
        [DisplayName("Suburb")]
        [Required]
        public string Suburb { get; set; }
        [DisplayName("State")]
        [Required]
        public string State { get; set; }
        [DisplayName("Postcode")]
        [Required]
        [StringLength(4, ErrorMessage ="Please enter a valid postcode", MinimumLength=4)]
        public string Postcode { get; set; }

    }
}
