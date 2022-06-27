using DataAccess.Context;
using DataAccess.Context.Entity;


namespace EJournalServices.Managers
{
    public class SubjectManager : ISubjectManager
    {
        private readonly EJournalDbContext _context;

        public SubjectManager(EJournalDbContext context)
        {
            _context = context;
        }
               

        public List<Subject> GetSubjectsFromDB()
        {
           return _context.Subjects.ToList(); 
              
        }

        public void AddSubject(Subject newSubject)
        {
            _context.Subjects.Add(newSubject);
            _context.SaveChanges();
        }
    }
}
