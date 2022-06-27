using DataAccess.Context.Entity;


namespace EJournalServices.Managers
{
    public interface IStudentManager
    {
        public List<Student> GetStudentsFromDB();

        public void AddStudent(Student student);
    }
}
