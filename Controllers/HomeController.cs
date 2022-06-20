using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        
        public HomeController()
        {
            DataBase.GetDataFromDB();
            
        }

        public IActionResult Index(int? selectedCategory)
        { 
            var homeModel = new HomeIndexModel
            {
                Categories = DataBase.CategoriesList,
                //Products = DataBase.ProductsList
                //                   .Where(p => p.CategoryId == selectedCategory)
                //                   .ToList(),
                SelectedCategory = selectedCategory
            };

            return View(homeModel);
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}