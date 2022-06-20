using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Student_AddStudent_Model
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

    }
}
