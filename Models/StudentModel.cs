using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public int YearOfBirth { get; set; }

        [Required]
        public string Class { get; set; }

        public List<GradeModel> Grades { get; set; }

        public double AverageGrade { get; set; }

    }
}
