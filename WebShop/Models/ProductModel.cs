using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
       
        [Required]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public SubcategoryModel Subcategory { get; set; }

        //public List<ShoppingCart> Carts { get; set; }

    }
}
