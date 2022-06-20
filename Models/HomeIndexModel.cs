namespace WebApplication1.Models
{
    public class HomeIndexModel
    {
        public HomeIndexModel()
        {
            Categories = new List<CategoriesModel>();
        }
        public List<CategoriesModel> Categories { get; set; }

        public int? SelectedCategory { get; set; }
    }
}
