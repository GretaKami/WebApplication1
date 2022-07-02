namespace DataAccess.Context.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
    }
}
