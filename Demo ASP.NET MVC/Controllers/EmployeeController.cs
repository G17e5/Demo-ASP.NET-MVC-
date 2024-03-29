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

            public EmployeeController(IEmployeeRepository employeeRepo, IWebHostEnvironment env)
            {
                _employeeRepo = employeeRepo;
                _env = env;
            }
            public IActionResult Index()
            {
                var employees = _employeeRepo.GetAll();
                return View(employees);
            }

            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Create(Employee employee)
            {
                if (ModelState.IsValid)
                {
                    var count = _employeeRepo.Add(employee);
                    if (count > 0)
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
