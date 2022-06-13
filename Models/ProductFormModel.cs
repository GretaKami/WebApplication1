using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ProductFormModel
    {
        [Required]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public List<CategoriesModel> CategoriesList { get; set; }
    }
}
