namespace WebApplication1.Context.Entity
{
    public class Grade
    {
        public int Id { get; set; }

        public int Mark { get; set; }

        public string String { get; set; }

        public Student Student { get; set; }

        public Subject Subject { get; set; }


    }
}
