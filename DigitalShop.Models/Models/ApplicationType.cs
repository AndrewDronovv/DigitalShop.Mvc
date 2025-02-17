using System.ComponentModel.DataAnnotations;

namespace DigitalShop.Models
{
    public class ApplicationType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
