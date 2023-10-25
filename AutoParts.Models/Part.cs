using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
    }
}
