using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalShop.Mvc.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string Description { get; set; }
        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        public string? Image { get; set; }

        [Display(Name = "Category type")]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category? Category { get; set; }

        [Display(Name = "Application type")]
        public int ApplicationTypeId { get; set; }
        public virtual ApplicationType? ApplicationType { get; set; }
    }
}
