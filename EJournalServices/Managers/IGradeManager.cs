using DataAccess.Context.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJournalServices.Managers
{
    public interface IGradeManager
    {
        public List<Grade> GetGradesFromDB();

        public void AddGrade(Grade grade);
    }
}
