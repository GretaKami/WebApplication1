using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class CategoryModel
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        public List<SubcategoryModel> Subcategories { get; set; }
    }
}
