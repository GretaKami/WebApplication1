using DataAccess.Context;
using DataAccess.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopServices.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly WebShopDbContext _context;
        public CategoryManager(WebShopDbContext context)
        {
            _context = context;
        }
        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public List<Category> GetCategoriesFromDB()
        {
            List<Category> categories = _context.Categories.ToList();

            return categories;

        }
    }
}
