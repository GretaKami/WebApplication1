using WebApplication1.Models;

namespace WebApplication1
{
    public static class DataBase
    {
        
        public static List<CategoriesModel> CategoriesList = new List<CategoriesModel> {
             new CategoriesModel { ID = 1, Name = "Computers" },
             new CategoriesModel{ID = 2, Name = "Smart phones"},
             new CategoriesModel { ID = 3, Name = "Tablets" }
        };


        public static List<ProductModel> ProductsList = new List<ProductModel>
            {
                new ProductModel{Name = "HP", CategoryName = "Computers", Price = 987.5},
                new ProductModel{Name =  "Asus", CategoryName = "Computers", Price = 885.99},
                new ProductModel { Name = "Huawei p30", CategoryName = "Smart phones", Price = 335.76 }
            };
    }
}
