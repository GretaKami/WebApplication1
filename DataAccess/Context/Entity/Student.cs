namespace DataAccess.Context.Entity
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int YearOfBirth { get; set; }

        public string Class { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}
