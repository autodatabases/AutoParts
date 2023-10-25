using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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


    }
}
