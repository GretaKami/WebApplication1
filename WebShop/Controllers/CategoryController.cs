using DataAccess.Context.Entities;
using Microsoft.AspNetCore.Mvc;
using WebShop.Extensions;
using WebShop.Models;
using WebShopServices.Managers;

namespace WebShop.Controllers
{
    public class CategoryController : Controller
    {
        public List<CategoryModel> categoriesList;
        public List<ProductModel> productsList;

        private readonly ICategoryManager _categoryManager;
        private readonly IProductManager _productManager;
       
        public CategoryController(ICategoryManager categoryManager, IProductManager productManager)
        {
            _categoryManager = categoryManager;
            _productManager = productManager;

            categoriesList = _categoryManager.GetCategoriesFromDB().Select(c => c.ToModel()).ToList();

            productsList = _productManager.GetProductsFromDB().Select(p => p.ToModel()).ToList();

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
            CategoryModel category = new CategoryModel();

            return View(category);
        }

        [HttpPost]
        public IActionResult CreateForm(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                Category newCategory = new Category
                {
                    Title = category.Title
                };

                _categoryManager.AddCategory(newCategory);
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}
