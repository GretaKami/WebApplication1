using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class GradeModel
    {
        public int Id { get; set; }

        [Required]
        public int Mark { get; set; }

        public string Description { get; set; }

        [Required]
        public StudentModel Student { get; set; }

        [Required]
        public SubjectModel Subject { get; set; }
    }
}
