using DataAccess.Context.Entities;
using WebShopServices.Managers;
using WebShop.Models;

namespace WebShop.Extensions
{
    public static class SubjectExtensions
    {
        
        //public static SubjectModel ToModel(this Subject subject, List<GradeModel>? gradeList)
        //{
        //    var grades = gradeList.Where(g => g.Subject.Id == subject.Id).ToList();

        //    var subjectModel = new SubjectModel
        //    {
        //        Id = subject.Id,
        //        Title = subject.Title,
        //        Grades = grades
        //    };

        //    return subjectModel;
        //}

        //public static void AddNewSubjectToDb(this Subject subject, Subject_AddSubject_Model newSubject,
        //    ISubjectManager _subjectManager)
        //{
        //    subject.Title = newSubject.Title;


        //    _subjectManager.AddSubject(subject);
        //}


    }
}
