using DataAccess.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopServices.Managers
{
    public interface ICategoryManager
    {
        public List<Category> GetCategoriesFromDB();

        public void AddCategory(Category category);
    }
}
