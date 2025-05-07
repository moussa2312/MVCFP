using Demo.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoPL.Controllers
{
    public class EmployeeController (IEmployeeServices _employeeServices) : Controller
    {

        public IActionResult Index()
        {
            var Employees = _employeeServices.GetAllEmployees();
            return View(Employees);
        }
    }
}
