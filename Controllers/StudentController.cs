using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;
using WebApplication1.Context.Entity;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private readonly EJournalDbContext _context;
        private List<StudentModel> studentList;
        public StudentController(EJournalDbContext context)
        {
            _context = context;
            studentList = new List<StudentModel>();
        }

        
        public IActionResult Index(string sort)
        {
            studentList = DataBase.GetStudentsFromDb(_context);
            
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
                var newStudent = new Student
                {
                    Name = student.Name,
                    Surname = student.Surname,
                    YearOfBirth = student.YearOfBirth,
                    Class = student.Class
                };

                _context.Students.Add(newStudent);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult View(int id)
        {
            studentList = DataBase.GetStudentsFromDb(_context);

            StudentModel student = new StudentModel();

            student = studentList.First(x => x.Id == id);

            return View(student);
        }
    }
}
