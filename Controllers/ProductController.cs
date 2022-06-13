using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        List<ProductModel> productsList;
        public ProductController()
        {
            productsList = DataBase.ProductsList;
        }
        public IActionResult Index()
        {
            productsList.Sort((x, y) => y.Price.CompareTo(x.Price));
            return View(productsList);
        }

        public IActionResult ProductView(string name)
        {
            var product = productsList.Find(product => product.Name == name);

            return View(product);
        }

        [HttpGet]
        public IActionResult CreateForm()
        {
            ProductFormModel newProduct = new ProductFormModel();
            newProduct.CategoriesList = DataBase.CategoriesList;
            return View(newProduct);
        }

        [HttpPost]
        public IActionResult CreateForm(ProductFormModel newProduct)
        {
            if (ModelState.IsValid)
            {
                ProductModel product = new ProductModel
                {
                    Name = newProduct.Name,
                    Price = newProduct.Price,
                    Description = newProduct.Description,
                    CategoryName = newProduct.CategoryName
                };
                DataBase.ProductsList.Add(product);
                return RedirectToAction("Index");

            }
            newProduct.CategoriesList = DataBase.CategoriesList;
            return View(newProduct);
        }
    }
}
