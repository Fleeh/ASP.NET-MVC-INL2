using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETWEBCORE.Models.data.Entities
{
    public class ImageEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Upload File")]
        public string FileName { get; set; }

        [NotMapped]
        [Display(Name = "Upload File")]
        public IFormFile File { get; set; }
    }
}
