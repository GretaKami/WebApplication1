using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;
using WebApplication1.Context.Entity;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GradeController : Controller
    {
        private readonly EJournalDbContext _context;

        public GradeController(EJournalDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string sort)
        {
            List<GradeModel> gradeList = new List<GradeModel>();
            using (_context)
            {              
                gradeList = _context.Grades.Select(g => new GradeModel
                {
                    Id = g.Id,
                    Mark = g.Mark,
                    Description = g.String,
                    Student = new StudentModel { 
                        Id = g.Student.Id,
                        Name = g.Student.Name,
                        Surname = g.Student.Surname,
                        YearOfBirth = g.Student.YearOfBirth,
                        Class = g.Student.Class
                    
                    },
                    Subject = new SubjectModel
                    {
                        Id = g.Subject.Id,
                        Title = g.Subject.Title
                    }                 

                }).ToList();
                
            }

            if(sort == "Id")
            {
                gradeList = gradeList.OrderBy(g => g.Id).ToList();
            }
            else if (sort == "Grade")
            {
                gradeList = gradeList.OrderByDescending(g => g.Mark).ToList();
            }

            return View(gradeList);
        }

        [HttpGet]
        public IActionResult AddGrade()
        {
            Grade_AddGrade_Model grade = new Grade_AddGrade_Model();
            return View(grade);
        }

        [HttpPost]
        public IActionResult AddGrade(Grade_AddGrade_Model grade)
        {           
            ModelState.Remove(nameof(grade.ErrorMessageSubject));
            ModelState.Remove(nameof(grade.ErrorMessageStudent));

            if (ModelState.IsValid)
            {
                var student = new Student();
                var subject = new Subject();

                student = _context.Students.FirstOrDefault
                    (s => (s.Name == grade.StudentName && s.Surname == grade.StudentSurname));

                subject = _context.Subjects.FirstOrDefault(s => s.Title == grade.SubjectTitle);

                if (student == null)
                {
                    grade.ErrorMessageStudent = "Such student doesn't exist";
                    return View(grade);

                }
                else if(subject == null)
                {
                    grade.ErrorMessageSubject = "Such subject doesn't exist";
                    return View(grade);
                } 
                else
                {
                    var newGrade = new Grade
                    {
                        Mark = grade.Mark,
                        String = grade.Description,
                        Student = student,
                        Subject = subject
                    };

                    _context.Grades.Add(newGrade);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            return View(grade);
        }

        [HttpGet]
        public IActionResult AddGradeSelection()
        {
            var studentList = DataBase.GetStudentsFromDb(_context);
            var subjectList = DataBase.GetSubjectsFromDb(_context);

            Grade_AddGradeSelection_Model grade = new Grade_AddGradeSelection_Model();
            grade.Students = studentList;
            grade.Subjects = subjectList;

            return View(grade);
        }

        [HttpPost]
        public IActionResult AddGradeSelection(Grade_AddGradeSelection_Model grade)
        {
            ModelState.Remove(nameof(grade.Students));
            ModelState.Remove(nameof(grade.Subjects));

            if (ModelState.IsValid)
            {
                var student = new Student();
                var subject = new Subject();

                student = _context.Students.First(s => (s.Id == grade.SelectedStudentId));

                subject = _context.Subjects.First(s => s.Id == grade.SelectedSubjectId);

                var newGrade = new Grade
                {
                    Mark = grade.Mark,
                    String = grade.Description,
                    Student = student,
                    Subject = subject
                };

                _context.Grades.Add(newGrade);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
