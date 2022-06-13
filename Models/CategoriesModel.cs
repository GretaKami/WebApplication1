using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CategoriesModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
