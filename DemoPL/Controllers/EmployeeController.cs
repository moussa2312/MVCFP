using Demo.BLL.Dto.EmployeeDto;
using Demo.BLL.DTO;
using Demo.BLL.Services.Clases;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Models.Emp_Model;
using DemoPL.ViewModels;
using DemoPL.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;

namespace DemoPL.Controllers
{
    public class EmployeeController(IEmployeeServices _employeeServices, ILogger<EmployeeController> _Logger, IWebHostEnvironment _environment) : Controller
    {

        public IActionResult Index()
        {
            TempData.Keep();

            var Employees = _employeeServices.GetAllEmployees();
            //Binding through views dictionary : transfer data from action to view
            // ViewData
            // ViewBag

            //ViewData["Message"] = "Hello view data";

            ViewBag.Message = "Hello view bag";
            return View(Employees);
        }

        #region Create Employee

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid) //server side validation
            {
                try
                {
                    var employeeCreatedDto = new CreatedEmpDto()
                    {
                        Name = employeeViewModel.Name,
                        Age = employeeViewModel.Age,
                        Salary = employeeViewModel.Salary,
                        Address = employeeViewModel.Address,
                        IsActive = employeeViewModel.IsActive,
                        Email = employeeViewModel.Email,
                        PhoneNumber = employeeViewModel.PhoneNumber,
                        HiringDate = employeeViewModel.HiringDate,
                        CreatedBy = employeeViewModel.CreatedBy,
                        EmployeeType = employeeViewModel.EmployeeType,
                        Gender = employeeViewModel.Gender,


                    };
                    int result = _employeeServices.CreateEmployee(employeeCreatedDto);
                    if (result > 0)
                    {
                        TempData["Message"] = "Employee Created Successfully";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Message"] = "Failed to create Employee";
                        ModelState.AddModelError(string.Empty, "Failed to create Employee");
                        return RedirectToAction(nameof(Index));

                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (optional)
                    // 1. Development => Log to console and return same view with error msg
                    // 2. Deployment => Log to file and return same view with error msg
                    //_Logger.LogError(ex, "Error creating Employee");
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(employeeViewModel);
        }


        #endregion

        #region Details Action 

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("Employee ID is required.");
            }
            var employee = _employeeServices.GetEmployeeById(id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("Employee ID is required.");
            }
            var employee = _employeeServices.GetEmployeeById(id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            var employeeDetailsDto = new EmployeeViewModel()
            {
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                Address = employee.Address,
                IsActive = employee.IsActive,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                CreatedBy = employee.CreatedBy,
                CreatedOn = employee.CreatedOn,
                Gender = Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
            };
            return View(employeeDetailsDto);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, EmployeeViewModel EmpViewModel)
        {
            if (!ModelState.IsValid) return View(EmpViewModel);

            try
            {
                var employeeCreatedDto = new UpdatedEmployeeDto()
                {
                    Id = id.Value,
                    Name = EmpViewModel.Name,
                    Age = EmpViewModel.Age,
                    Salary = EmpViewModel.Salary,
                    Address = EmpViewModel.Address,
                    IsActive = EmpViewModel.IsActive,
                    Email = EmpViewModel.Email,
                    PhoneNumber = EmpViewModel.PhoneNumber,
                    HiringDate = EmpViewModel.HiringDate,
                    CreatedBy = EmpViewModel.CreatedBy,
                    EmployeeType = EmpViewModel.EmployeeType,
                    Gender = EmpViewModel.Gender,


                };

                int result = _employeeServices.UpdateEmployee(employeeCreatedDto);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to update employee");
                }

            }

            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    _Logger.LogError(ex, "Error creating department");
                }
            }

            return View(EmpViewModel);

        }

        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var deleteEmployee = _employeeServices.DeleteEmployee(id);
                if (deleteEmployee)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to delete employee");
                    return RedirectToAction(nameof(Index));

                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    _Logger.LogError(ex, "Error deleting employee");
                }

                return RedirectToAction(nameof(Index));

            }
            #endregion
        }
    }
}
