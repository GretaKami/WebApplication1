using DataAccess.Context.Entities;
using WebShopServices.Managers;
using WebShop.Models;

namespace WebShop.Extensions
{
    public static class GradeExtensions
    {
        //public static GradeModel ToModel(this Grade grade)
        //{   
        //    var gradeModel = new GradeModel
        //    {
        //        Id = grade.Id,
        //        Description = grade.String,
        //        Mark = grade.Mark,
        //        Subject = new SubjectModel
        //            {
        //                Id = grade.Subject.Id,
        //                Title = grade.Subject.Title
        //            },
        //        Student = new StudentModel
        //            {
        //                Id = grade.Student.Id,
        //                Name = grade.Student.Name,
        //                Surname = grade.Student.Surname,
        //                Class = grade.Student.Class
        //            }
        //    };

        //    return gradeModel;
        //}

        //public static void AddNewGradeToDb(this Grade grade, Grade_AddGrade_Model newGrade,
        //    Student student, Subject subject, IGradeManager _gradeManager)
        //{
        //    grade.Mark = newGrade.Mark;
        //    grade.String = newGrade.Description;
        //    grade.Student = student;
        //    grade.Subject = subject;

        //    _gradeManager.AddGrade(grade);
        //}

        //public static void AddNewGradeToDb(this Grade grade, IGradeManager _gradeManager,
        //    IStudentManager _studentManager, ISubjectManager _subjectManager,
        //    Grade_AddGradeSelection_Model newGrade)
        //{
        //    var student = _studentManager.GetStudentsFromDB().First
        //        (s => (s.Id == newGrade.SelectedStudentId));

        //    var subject = _subjectManager.GetSubjectsFromDB().First
        //        (s => s.Id == newGrade.SelectedSubjectId);

        //    grade.Mark = newGrade.Mark;
        //    grade.String = newGrade.Description;
        //    grade.Student = student;
        //    grade.Subject = subject;

        //    _gradeManager.AddGrade(grade);
        //}



    }
}
