using DataAccess.Context.Entities;
using WebShop.Models;

namespace WebShop.Extensions
{
    public static class ProductExtension
    {
        public static ProductModel ToModel(this Product product)
        {
            ProductModel productModel = new ProductModel 
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price

            };

            return productModel;
        }
    }
}
