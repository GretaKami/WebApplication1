using DataAccess.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopServices.Managers
{
    public interface IProductManager
    {
        public List<Product> GetProductsFromDB();

        public void AddProduct(Product product);
    }
}
