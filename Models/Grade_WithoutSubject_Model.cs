namespace WebApplication1.Models
{
    public class Grade_WithoutSubject_Model
    {
        public int Id { get; set; }
      
        public int Mark { get; set; }

        public string Description { get; set; }
        
        public StudentModel Student { get; set; }
               
    }
}
