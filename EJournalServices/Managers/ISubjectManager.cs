using DataAccess.Context.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalServices.Managers
{
    public interface ISubjectManager
    {
        public List<Subject> GetSubjectsFromDB();

        public void AddSubject(Subject newSubject);
    }
}
