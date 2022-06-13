using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public int YearOfBirth { get; set; }

        [Required]
        [MaxLength(100)]
        public string Position { get; set; }

        [Required]
        [MaxLength(100)]
        public string Department { get; set; }

        
    }
}
