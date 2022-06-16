using WebApplication1.DB;
using WebApplication1.Models;

namespace WebApplication1
{
    public static class DataBase
    {

        public static List<CategoriesModel> CategoriesList = new List<CategoriesModel>();
        //{
        //     new CategoriesModel { ID = 1, Name = "Computers" },
        //     new CategoriesModel{ID = 2, Name = "Smart phones"},
        //     new CategoriesModel { ID = 3, Name = "Tablets" }
        //};


        public static List<ProductModel> ProductsList = new List<ProductModel>();
            //{
            //    new ProductModel{Name = "HP", CategoryName = "Computers", Price = 987.5},
            //    new ProductModel{Name =  "Asus", CategoryName = "Computers", Price = 885.99},
            //    new ProductModel { Name = "Huawei p30", CategoryName = "Smart phones", Price = 335.76 }
            //};

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
            
        }

        

    }
}
