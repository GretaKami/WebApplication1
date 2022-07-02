namespace DataAccess.Context.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Subcategory> Subcategories { get; set; }
    }
}
