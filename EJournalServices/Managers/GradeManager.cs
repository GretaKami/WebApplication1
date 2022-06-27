using DataAccess.Context;
using DataAccess.Context.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalServices.Managers
{
    public class GradeManager : IGradeManager
    {
        private readonly EJournalDbContext _context;

        public GradeManager(EJournalDbContext context)
        {
            _context = context;
        }
        public List<Grade> GetGradesFromDB()
        {          

            List<Grade> grades = _context.Grades.Select(grade => new Grade
            {
                Id = grade.Id,
                String = grade.String,
                Mark = grade.Mark,
                Subject = new Subject
                {
                    Id = grade.Subject.Id,
                    Title = grade.Subject.Title
                },
                Student = new Student
                {
                    Id = grade.Student.Id,
                    Name = grade.Student.Name,
                    Surname = grade.Student.Surname,
                    YearOfBirth = grade.Student.YearOfBirth,
                    Class = grade.Student.Class
                }
            }).ToList();

            return grades;
        }

        public void AddGrade(Grade grade)
        {
            _context.Grades.Add(grade);
            _context.SaveChanges();
        }
    }
}
