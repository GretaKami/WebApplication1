using Microsoft.AspNetCore.Mvc;
using DataAccess.Context;
using DataAccess.Context.Entity;
using WebApplication1.Models;
using EJournalServices.Managers;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeManager _gradeManager;
        private readonly IStudentManager _studentManager;
        private readonly ISubjectManager _subjectManager;

        private List<GradeModel> gradeList;

        public GradeController(IGradeManager gradeManager,
            IStudentManager studentManager, ISubjectManager subjectManager)
        {
            _gradeManager = gradeManager;
            _studentManager = studentManager;
            _subjectManager = subjectManager;

            gradeList = _gradeManager.GetGradesFromDB().Select(g => g.ToModel())
                .ToList();
        }
        public IActionResult Index(string sort)
        {           

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
                var student = _studentManager.GetStudentsFromDB().FirstOrDefault
                (s => (s.Name == grade.StudentName && s.Surname == grade.StudentSurname));

                var subject = _subjectManager.GetSubjectsFromDB().FirstOrDefault
                    (s => s.Title == grade.SubjectTitle);

                if (student == null)
                {
                    grade.ErrorMessageStudent = "Such student doesn't exist";
                    return View(grade);

                }
                else if (subject == null)
                {
                    grade.ErrorMessageSubject = "Such subject doesn't exist";
                    return View(grade);
                }
                else
                {
                    Grade newGrade = new Grade();
                    newGrade.AddNewGradeToDb(grade, student, subject, _gradeManager);

                    return RedirectToAction("Index");
                }
                
            }
            return View(grade);
        }

        [HttpGet]
        public IActionResult AddGradeSelection()
        {
            Grade_AddGradeSelection_Model grade = new Grade_AddGradeSelection_Model();

            grade.Students = _studentManager.GetStudentsFromDB()
                .Select(s => s.ToModel(gradeList)).ToList();

            grade.Subjects = _subjectManager.GetSubjectsFromDB()
                .Select(s => s.ToModel(gradeList)).ToList();

            return View(grade);
        }

        [HttpPost]
        public IActionResult AddGradeSelection(Grade_AddGradeSelection_Model grade)
        {
            ModelState.Remove(nameof(grade.Students));
            ModelState.Remove(nameof(grade.Subjects));

            if (ModelState.IsValid)
            {               

                Grade newGrade = new Grade();
                newGrade.AddNewGradeToDb(_gradeManager, _studentManager,
                    _subjectManager, grade);

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
