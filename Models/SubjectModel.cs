using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public List<GradeModel> Grades { get; set; }

        public SubjectModel()
        {
            Grades = new List<GradeModel>();
        }
               
    }
}
