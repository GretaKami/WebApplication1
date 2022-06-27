using DataAccess.Context.Entity;
using EJournalServices.Managers;
using WebApplication1.Models;

namespace WebApplication1.Extensions
{
    public static class StudentExtensions
    {
        public static StudentModel ToModel(this Student student, List<GradeModel> gradeList)
        {
            var grades = gradeList.Where(grade => grade.Student.Id == student.Id)
                .ToList();
                                  

            var studentModel = new StudentModel
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                YearOfBirth = student.YearOfBirth,
                Class = student.Class,
                Grades = grades
            };

            if (grades.Count > 0)
            {
                studentModel.AverageGrade = Math.Round(
                       (double)(grades.Sum(x => x.Mark) / grades.Count), 2);
            }

            return studentModel;
        }

        public static void AddNewStudentToDb(this Student student, Student_AddStudent_Model newStudent,
         IStudentManager _studentManager)
        {
            student.Name = newStudent.Name;
            student.Surname = newStudent.Surname;
            student.YearOfBirth = newStudent.YearOfBirth;
            student.Class = newStudent.Class;

            _studentManager.AddStudent(student);
        }
    }
}
