namespace DataAccess.Context.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public Subcategory Subcategory { get; set; }
        public List<ShoppingCart> Carts { get; set; }

    }
}
