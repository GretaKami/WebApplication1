using DataAccess.Context.Entities;
using Microsoft.AspNetCore.Mvc;
using WebShop.Extensions;
using WebShop.Models;
using WebShopServices.Managers;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;

        List<ProductModel> productsList;
        public ProductController(IProductManager productManager, ICategoryManager categoryManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;

            productsList = _productManager.GetProductsFromDB().Select(p => p.ToModel()).ToList();
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
            newProduct.CategoriesList = _categoryManager.GetCategoriesFromDB().Select(c => c.ToModel()).ToList();

            return View(newProduct);
        }

        [HttpPost]
        public IActionResult CreateForm(ProductFormModel product)
        {
            if (ModelState.IsValid)
            {
                Product newProduct = new Product
                {
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description
                    
                };

                _productManager.AddProduct(newProduct);
                return RedirectToAction("Index");

            }

            return View(product);
        }
    }
}
