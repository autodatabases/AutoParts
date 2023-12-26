using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoParts.Models
{
    public class PartCategory
    {
        [Key]
        [DisplayName("Category ID")]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        public int VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        [ValidateNever]
        public Vehicle Vehicle { get; set; }


    }
}
