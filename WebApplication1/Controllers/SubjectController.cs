using Microsoft.AspNetCore.Mvc;
using DataAccess.Context;
using DataAccess.Context.Entity;
using WebApplication1.Models;
using EJournalServices.Managers;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers
{
    public class SubjectController : Controller
    {        
        private readonly ISubjectManager _subjectManager;
        private readonly IGradeManager _gradeManager;

        private List<SubjectModel> subjectList;
        private List<GradeModel> gradeList;

        public SubjectController(ISubjectManager subjectManager, 
            IGradeManager gradeManager)
        {
            _subjectManager = subjectManager;
            _gradeManager = gradeManager;

            gradeList = _gradeManager.GetGradesFromDB().Select(g => g.ToModel()).ToList();
            subjectList = _subjectManager.GetSubjectsFromDB().Select(s => s.ToModel(gradeList)).ToList();
        }

        public IActionResult Index(string sort)
        {
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
                var newSubject = new Subject();
                newSubject.AddNewSubjectToDb(subject, _subjectManager);
                                

                return RedirectToAction("Index");
            }
            return View(subject);
        }


        [HttpGet]
        public IActionResult View(int id)
        {  
            var selectedSubject = subjectList.Find(x => x.Id == id);

            return View(selectedSubject);
        }
    }
}
