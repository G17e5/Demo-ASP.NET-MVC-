using AutoMapper;
using Demo_ASP.NET_MVC.BLL.Interfaces;
using Demo_ASP.NET_MVC.DAL.Models;
using Demo_ASP.NET_MVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Demo_ASP.NET_MVC.Controllers
{
   public class EmployeeController : Controller
        {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;
     //   private readonly IEmployeeRepository _employeeRepo;
            private readonly IWebHostEnvironment _env;
       //   private readonly IDepartmentRepository _departmentRepo;

        public EmployeeController(IUnitOfWork UnitOfwork, IMapper mapper, IWebHostEnvironment env )
            {
                _unitOfwork = UnitOfwork;
                _mapper = mapper;
                _env = env;
               // _employeeRepo = employeeRepo;
                //_departmentRepo = departmentRepo;
               /*binding views dictionary [one way]
            //1.View Data
           /// ViewData["Message"] = "hii ASP.NET";  // dictionary
            //2.ViewBag
           /// ViewBag.Message ="Hello ASP.NET";     // Dynamic object
            */
        }



            public IActionResult Index( string searchInput)
            {
                TempData.Keep();

               var employees = Enumerable.Empty<Employee>();


               if (string.IsNullOrEmpty(searchInput))
                    employees = _unitOfwork.EmployeeRepository.GetAll();                  
               else
                    employees = _unitOfwork.EmployeeRepository.SearcByhName(searchInput.ToLower());

                var MappedEmp = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);

                return View(employees);
            

            }

            public IActionResult Create()
            {
               //ViewData["Departments"] = _departmentRepo.GetAll();
               //ViewBag.Departments = _departmentRepo.GetAll();
               return View();
            }

            [HttpPost]
            public IActionResult Create(EmployeeViewModel employeeVM)
            {
            //manual mappmed
            /* var MappedEmp = new Employee()
          {
              Name = employeeVM.Name,
              Age = employeeVM.Age,
              Address = employeeVM.Address,
              Salary = employeeVM.Salary,
              Email = employeeVM.Email,
              Isactive = employeeVM.Isactive,
              HireDate = employeeVM.HireDate
          };*/

            var MappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                if (ModelState.IsValid)
                {
                _unitOfwork.EmployeeRepository.Add(MappedEmp);

                var count = _unitOfwork.Complete();

                //3.TempData
                    if (count > 0)
                        TempData["Message"] = "Department is Created";

                    else
                        TempData["Message"] = "AN Erorr not Created";    

                    return RedirectToAction(nameof(Index));
                }
                return View(employeeVM);

            }


            //Department//Details/10
            //Department//Details
            [HttpGet]

            public IActionResult Details(int? id, string ViewName = "Details")
            {
                if (!id.HasValue)
                    return BadRequest(); // 400

                var employee = _unitOfwork.EmployeeRepository.Get(id.Value);

            var MappedEmp = _mapper.Map<Employee, EmployeeViewModel> (employee);


            if (employee is null)
                    return NotFound();

             
                return View(ViewName, MappedEmp);
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
            public IActionResult Edit([FromRoute] int id, EmployeeViewModel employeeVN)
            {


            if (id != employeeVN.Id)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                    return View(employeeVN);

                try
                {
                   var MappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVN);
                _unitOfwork.EmployeeRepository.Update(MappedEmp);
                _unitOfwork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    //log Exception
                    if (_env.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                        ModelState.AddModelError(string.Empty, "Erorr has Occurred during update Department ");
                    return View(employeeVN);
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
            public IActionResult Delete(EmployeeViewModel employeeVM)
            {
                var MappedEmp = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);

            _unitOfwork.EmployeeRepository.Delete(MappedEmp);
            _unitOfwork.Complete();
                    return RedirectToAction(nameof(Index));
            }



        }
    
    
}
