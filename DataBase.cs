using WebApplication1.Models;

namespace WebApplication1
{
    public static class DataBase
    {
        
       public static List<EmployeeModel> EmployeeList = new List<EmployeeModel>
       {
           new EmployeeModel
           {
               ID = 1,
               Name = "Greta",
               Surname = "Kaminskaite",
               YearOfBirth = 1999,
               Position = ".NET specialist",
               Department = "IT"
           },

            new EmployeeModel
           {
               ID = 2,
               Name = "Akvile",
               Surname = "Vas",
               YearOfBirth = 1997,
               Position = "JavaScript specialist",
               Department = "IT"
           },

             new EmployeeModel
           {
               ID = 3,
               Name = "Jonas",
               Surname = "Kaminskas",
               YearOfBirth = 2000,
               Position = "Finance analyst",
               Department = "Finance"
           }
       };

       
    }

    
}
