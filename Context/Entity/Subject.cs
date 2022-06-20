namespace WebApplication1.Context.Entity
{
    public class Subject
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Student> Students { get; set; }
    }
}
