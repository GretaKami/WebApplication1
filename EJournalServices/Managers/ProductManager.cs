using DataAccess.Context;
using DataAccess.Context.Entities;


namespace WebShopServices.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly WebShopDbContext _context;

        public ProductManager(WebShopDbContext context)
        {
            _context = context;
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public List<Product> GetProductsFromDB()
        {
            List<Product> products = _context.Products.ToList();

            return products;
        }
    }
}
