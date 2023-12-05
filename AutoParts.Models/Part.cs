using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoParts.Models
{
    public class Part
    {
        [Key]
        public int PartId { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage ="Car Part Name cannot be empty")]
        [DisplayName("Part Name")]
        public string PartName { get; set; }
        [Required]
        [DisplayName("Part Description")]
        public string Description { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public PartCategory Category { get; set; }
        public string ImageUrl { get; set; }
    }
}
