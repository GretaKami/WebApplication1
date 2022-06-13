using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index(string sort)
        {
            if (sort == "Surname")
            {
                DataBase.EmployeeList.Sort((x, y) => x.Surname.CompareTo(y.Surname));
            }
            else if (sort == "Department")
            {
                DataBase.EmployeeList.Sort((x, y) => x.Department.CompareTo(y.Department));
            }
            else { DataBase.EmployeeList.Sort((x, y) => x.ID.CompareTo(y.ID)); }

            return View(DataBase.EmployeeList);
        }

        public IActionResult EmployeeDepartments()
        {
            DepartmentModel departments = new DepartmentModel
            {
                Names = DataBase.EmployeeList.Select(x => x.Department).Distinct().ToList()
            };
           
           
            return View(departments);
        }


        [HttpGet]
        public IActionResult NewEmployee()
        {
            EmployeeModel employee = new EmployeeModel();
            employee.ID = DataBase.EmployeeList.Count+1;

            return View(employee);
        }

        [HttpPost]
        public IActionResult NewEmployee(EmployeeModel employee)
        {
            if (ModelState.IsValid && employee.YearOfBirth>1900)
            {
                employee.ID = DataBase.EmployeeList.Count + 1;
                DataBase.EmployeeList.Add(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}
