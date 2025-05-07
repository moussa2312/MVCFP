using Demo.BLL.DTO;
using Demo.BLL.Services.Interfaces;
using DemoPL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;

namespace DemoPL.Controllers
{
            //now we donot use the repository directly in the controller but we use the service layer
            //because any business logic should be in the service layer 
    public class DepartmentController(IDepartmentServices _departmentServices , ILogger<DepartmentController> _Logger , IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index()
        {
            var departments = _departmentServices.GetAllDepartment();

            return View( departments);
        }

        #region Create Department

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto dto)
        {
            if (ModelState.IsValid) //server side validation
            {
                try
                {
                    int result = _departmentServices.AddDepartment(dto);
                    if (result > 0)
                    {
                        //TempData["Success"] = "Department Created Successfully";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to create department");
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (optional)
                    // 1. Development => Log to console and return same view with error msg
                    // 2. Deployment => Log to file and return same view with error msg

                    if (_environment.IsDevelopment())
                    {
                        //_Logger.LogError(ex, "Error creating department");
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        _Logger.LogError(ex, "Error creating department");
                    }
                }
            }

            return View(dto); 


        }
        #endregion

        #region Details of Department

        [HttpGet]
        public IActionResult Details(int? id) 
        {
            if (!id.HasValue ) return BadRequest(); 
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department is null) return NotFound(); //404
            return View(department);
        }

        #endregion

        #region Edit Department

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department is null) return NotFound(); //404
            var departmenteditviewmodel = new DepartmentEditViewModel
            {
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateOfCreation = department.CreatedOn
            };


            return View(departmenteditviewmodel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id , DepartmentEditViewModel departmentEditViewModel)
        {
            if (!ModelState.IsValid)return View(departmentEditViewModel);

            try
            {
                var updateDepartment = new UpdateDeptDto
                {
                    Id = id.Value,
                    Name = departmentEditViewModel.Name,
                    Code = departmentEditViewModel.Code,
                    Description = departmentEditViewModel.Description,
                    DateOfCreation = departmentEditViewModel.DateOfCreation
                };
                int result = _departmentServices.UpdateDepartment(updateDepartment);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to update department");
                }

            }

            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    //_Logger.LogError(ex, "Error creating department");
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    _Logger.LogError(ex, "Error creating department");
                }
            }

            return View(departmentEditViewModel);

        }
        #endregion

        #region Delete Department

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department is null) return NotFound(); //404
            return View(department);
        }


        [HttpPost]

        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();
            try
            {
                bool result = _departmentServices.DeleteDepartment(id);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to delete department");
                    return RedirectToAction(nameof(Delete), new {id} );
                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    //_Logger.LogError(ex, "Error creating department");
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Delete), new { id });
                }
                else
                {
                    _Logger.LogError(ex, "Error creating department");
                    return View("Error");
                }
            }

        }
        #endregion


    }
}
