using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1
{
    public static class DataBase
    {
        public static List<StudentModel> GetStudentsFromDb(EJournalDbContext context)
        {
            List<StudentModel> studentList = new List<StudentModel>();

            studentList = context.Students.Select(x => new StudentModel
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                YearOfBirth = x.YearOfBirth,
                Class = x.Class
            }).ToList();

            foreach (var student in studentList)
            {
                student.Grades = context.Grades.Where(x => x.Student.Id == student.Id)
                                 .Select(x => new Grade_WithoutStudent_Model
                                 {
                                     Id = x.Id,
                                     Description = x.String,
                                     Mark = x.Mark,
                                     Subject = new SubjectModel
                                     {
                                         Id = x.Subject.Id,
                                         Title = x.Subject.Title
                                     }
                                 }).ToList();

                if (student.Grades.Count > 0)
                {
                    student.AverageGrade = Math.Round(
                          (double)(student.Grades.Sum(x => x.Mark) / student.Grades.Count), 2);
                }

            }

            return studentList;
        }

        public static List<SubjectModel> GetSubjectsFromDb(EJournalDbContext context)
        {
            List<SubjectModel> subjectList = new List<SubjectModel>();

            subjectList = context.Subjects.Select(x => new SubjectModel
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();

            foreach (var subject in subjectList)
            {
                subject.Grades = context.Grades.Where(x => x.Subject.Id == subject.Id).Select(
                    x => new Grade_WithoutSubject_Model
                    {
                        Id = x.Id,
                        Description = x.String,
                        Mark = x.Mark,
                        Student = new StudentModel
                        {
                            Id = x.Student.Id,
                            Name = x.Student.Name,
                            Surname = x.Student.Surname,
                            Class = x.Student.Class
                        }
                    }).ToList();
            }

            return subjectList;

        }
    }


}
