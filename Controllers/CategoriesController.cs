using Microsoft.AspNetCore.Mvc;
using WebApplication1.DB;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoriesController : Controller
    {
        public List<CategoriesModel> categoriesList;
        public List<ProductModel> productsList;
       
        public CategoriesController()
        {
            DataBase.GetDataFromDB();
            categoriesList = DataBase.CategoriesList;
            productsList = DataBase.ProductsList;

        }
        public IActionResult Index()
        {
            return View(categoriesList);
        }

        public IActionResult View(string name)
        {
            List<ProductModel> products = new List<ProductModel>();
            
            foreach(var product in productsList)
            {
                if(product.CategoryName == name)
                {
                    products.Add(product);
                }
            }

            products.Sort((x, y) => y.Price.CompareTo(x.Price));
           
            return View(products);
        }

        [HttpGet]
        public IActionResult CreateForm()
        {
            var category = new CategoriesModel();
            //{
            //    ID = DataBase.CategoriesList.Count + 1
            //};

            return View(category);
        }

        [HttpPost]
        public IActionResult CreateForm(CategoriesModel category)
        {
            ModelState.Remove(nameof(category.Products));

            if (ModelState.IsValid)
            {
                using(var db = new WebAppContext())
                {
                    var newCategory = new Category
                    {
                        Name = category.Name
                    };

                    db.Categories.Add(newCategory);
                    db.SaveChanges();
                }
                //DataBase.CategoriesList.Add(category);
                return RedirectToAction("Index", "Home");
            }
            return View(category);
        }
    }
}
