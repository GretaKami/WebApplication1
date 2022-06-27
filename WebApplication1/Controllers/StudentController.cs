using Microsoft.AspNetCore.Mvc;
using DataAccess.Context;
using DataAccess.Context.Entity;
using WebApplication1.Models;
using EJournalServices.Managers;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentManager _studentManager;
        private readonly IGradeManager _gradeManager;

        private List<StudentModel> studentList;
        private List<GradeModel> gradeList;
        public StudentController(IStudentManager studentManager,
            IGradeManager gradeManager)
        {
            _studentManager = studentManager;
            _gradeManager = gradeManager;

            gradeList = _gradeManager.GetGradesFromDB().Select(g => g.ToModel())
                .ToList();

            studentList = _studentManager.GetStudentsFromDB()
                .Select(s => s.ToModel(gradeList)).ToList();
        }

        
        public IActionResult Index(string sort)
        {
            
            if (sort == "Id")
            {
                studentList.Sort((x, y) => x.Id.CompareTo(y.Id));
            }
            else if (sort == "Name")
            {
                studentList = studentList.OrderBy(s => s.Surname).ThenBy(n => n.Name).ToList();
            }

           return View(studentList);
        }


        [HttpGet]
        public IActionResult AddStudent()
        {
            Student_AddStudent_Model student = new Student_AddStudent_Model();
            return View(student);
        }

        [HttpPost]
        public IActionResult AddStudent(Student_AddStudent_Model student)
        {
            
            if (ModelState.IsValid)
            {
                var newStudent = new Student();

                newStudent.AddNewStudentToDb(student, _studentManager);

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult View(int id)
        {          
            StudentModel student = studentList.First(x => x.Id == id);


            return View(student);
        }
    }
}
