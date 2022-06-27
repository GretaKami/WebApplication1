using DataAccess.Context;
using DataAccess.Context.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalServices.Managers
{
    public class StudentManager : IStudentManager
    {
        private readonly EJournalDbContext _context;

        public StudentManager(EJournalDbContext context)
        {
            _context = context;
        }
        public List<Student> GetStudentsFromDB()
        {
            return _context.Students.ToList();
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
    }
}
