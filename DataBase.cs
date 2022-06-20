using WebApplication1.DB;
using WebApplication1.Models;

namespace WebApplication1
{
    public static class DataBase
    {

        public static List<CategoriesModel> CategoriesList = new List<CategoriesModel>();
     

        public static List<ProductModel> ProductsList = new List<ProductModel>();

        public static void GetDataFromDB(){

            using (var db = new WebAppContext())
            {
                CategoriesList = db.Categories.Select(c => new CategoriesModel
                {
                    ID = c.Id,
                    Name = c.Name
                }).ToList();

                ProductsList = db.Products.Select(p => new ProductModel
                {
                    Id = p.Id,
                    Name= p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryId = p.CategoryId
                }).ToList();

            };

            foreach (var product in ProductsList)
            {
                product.CategoryName = CategoriesList.Find(c => c.ID == product.CategoryId).Name;
            }

            foreach(var category in CategoriesList)
            {
                category.Products = ProductsList.Where(p => p.CategoryId == category.ID).ToList();
            }
            
        }

        

    }
}
