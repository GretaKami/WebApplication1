using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public List<Grade_WithoutSubject_Model> Grades { get; set; }
               
    }
}
