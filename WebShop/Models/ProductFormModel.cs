using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class ProductFormModel
    {
        [Required]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public List<CategoryModel> CategoriesList { get; set; }
    }
}
