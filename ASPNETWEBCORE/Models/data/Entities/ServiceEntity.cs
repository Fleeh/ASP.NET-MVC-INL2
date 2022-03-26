using System.ComponentModel.DataAnnotations;

namespace ASPNETWEBCORE.Models.data.Entities
{
    public class ServiceEntity
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
