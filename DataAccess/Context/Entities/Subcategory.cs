namespace DataAccess.Context.Entities
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public List<Product> Products { get; set; }

    }
}
