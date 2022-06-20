using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;
using WebApplication1.Context.Entity;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SubjectController : Controller
    {
        private readonly EJournalDbContext _context;

        public SubjectController(EJournalDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string sort)
        {
            var subjectList = DataBase.GetSubjectsFromDb(_context);


            if (sort == "Id")
            {
                subjectList.Sort((x, y) => x.Id.CompareTo(y.Id));
            }
            else if(sort == "Title")
            {
                subjectList.Sort((x, y) => x.Title.CompareTo(y.Title));
            }

            return View(subjectList);
        }

        [HttpGet]
        public IActionResult AddSubject()
        {
            Subject_AddSubject_Model subject = new Subject_AddSubject_Model();
            return View(subject);
        }

        [HttpPost]
        public IActionResult AddSubject(Subject_AddSubject_Model subject)
        {
            ModelState.Remove(nameof(subject.Id));
            if (ModelState.IsValid)
            {
                var newSubject = new Subject
                {
                    Title = subject.Title
                };

                _context.Subjects.Add(newSubject);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(subject);
        }


        [HttpGet]
        public IActionResult View(int id)
        {           

            var subjectList = DataBase.GetSubjectsFromDb(_context);

            var selectedSubject = subjectList.Find(x => x.Id == id);

            return View(selectedSubject);
        }
    }
}
