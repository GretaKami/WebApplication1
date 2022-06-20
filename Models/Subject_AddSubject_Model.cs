using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Subject_AddSubject_Model
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

    }
}
