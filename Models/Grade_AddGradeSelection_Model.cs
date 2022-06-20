using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Grade_AddGradeSelection_Model
    {
        public int Id { get; set; }

        [Required]
        public int Mark { get; set; }

        [Required]
        public string Description { get; set; }

      
        public List<StudentModel> Students { get; set; }

        
        public List<SubjectModel> Subjects { get; set; }

        [Required]
        public int SelectedStudentId { get; set; }

        [Required]
        public int SelectedSubjectId { get; set; }

        //[Required]
        //public string StudentName { get; set; }

        //[Required(ErrorMessage = "Such student doesn't exist")]
        //public string StudentSurname { get; set; }


        //[Required(ErrorMessage = "Such subject doesn't exist")]
        //public string SubjectTitle { get; set; }

        
    }
}
