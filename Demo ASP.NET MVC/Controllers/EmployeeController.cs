using Demo_ASP.NET_MVC.BLL.Interfaces;
using Demo_ASP.NET_MVC.DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;

namespace Demo_ASP.NET_MVC.Controllers
{
   public class EmployeeController : Controller
        {
            private readonly IEmployeeRepository _employeeRepo;
            private readonly IWebHostEnvironment _env;
       //   private readonly IDepartmentRepository _departmentRepo;

        public EmployeeController(IEmployeeRepository employeeRepo, IWebHostEnvironment env )
            {
                _employeeRepo = employeeRepo;
                _env = env;
                //_departmentRepo = departmentRepo;
        }
            public IActionResult Index()
            {
              TempData.Keep();

               /*binding views dictionary [one way]
            //1.View Data
           /// ViewData["Message"] = "hii ASP.NET";  // dictionary
            //2.ViewBag
           /// ViewBag.Message ="Hello ASP.NET";     // Dynamic object
            */


                var employees = _employeeRepo.GetAll();
                return View(employees); 
            }

            public IActionResult Create()
            {
               //ViewData["Departments"] = _departmentRepo.GetAll();
               //ViewBag.Departments = _departmentRepo.GetAll();
            return View();
            }

            [HttpPost]
            public IActionResult Create(Employee employee)
            {
                if (ModelState.IsValid)
                {
                    var count = _employeeRepo.Add(employee);

                //3.TempData
                    if (count > 0)
                        TempData["Message"] = "Department is Created";

                    else
                        TempData["Message"] = "AN Erorr not Created";    

                    return RedirectToAction(nameof(Index));
                }
                return View(employee);

            }


            //Department//Details/10
            //Department//Details
            [HttpGet]

            public IActionResult Details(int? id, string ViewName = "Details")
            {
                if (!id.HasValue)
                    return BadRequest(); // 400

                var employee = _employeeRepo.Get(id.Value);

                if (employee is null)
                    return NotFound();


                return View(ViewName, employee);
            }


            [HttpGet]
            public IActionResult Edit(int? id)
            {


               //ViewData["Departments"] = _departmentRepo.GetAll();

               return Details(id, "Edit");

                /*if (!id.HasValue)
                    return BadRequest();

                var Employee = _employeesRepo.Get(id.Value);

                if (Employee is null)
                    return NotFound();


                return View(Employee);*/

            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            // [Authorize]
            public IActionResult Edit([FromRoute] int id, Employee employee)
            {

                if (id != employee.Id)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                    return View(employee);

                try
                {
                    _employeeRepo.Update(employee);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    //log Exception
                    if (_env.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                        ModelState.AddModelError(string.Empty, "Erorr has Occurred during update Department ");
                    return View(employee);
                }


            }



            //Department//Delete/10
            //Department//Delete
            [HttpGet]
            public IActionResult Delete(int? id)
            {

                return Details(id, "Delete");
            }


            /// /////////////////////////////////////////////////////////////

            [HttpPost]
            public IActionResult Delete(Employee employee)
            {
                _employeeRepo.Delete(employee);
                return RedirectToAction(nameof(Index));
            }



        }
    
    
}
