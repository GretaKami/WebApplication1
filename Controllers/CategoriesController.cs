using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoriesController : Controller
    {
        public List<CategoriesModel> categoriesList;
        public List<ProductModel> productsList;
       
        public CategoriesController()
        {
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
            //string categoryName = categoriesList[ID-1].Name;
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
            var category = new CategoriesModel
            {
                ID = DataBase.CategoriesList.Count + 1
            };

            return View(category);
        }

        [HttpPost]
        public IActionResult CreateForm(CategoriesModel category)
        {
            if (ModelState.IsValid)
            {
                DataBase.CategoriesList.Add(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}
