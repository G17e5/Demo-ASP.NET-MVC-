using Demo_ASP.NET_MVC.BLL.Interfaces;
using Demo_ASP.NET_MVC.DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;

namespace Demo_ASP.NET_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _uintOfWork;

        //private readonly IDepartmentRepository _departmentsRepo;

        private readonly IWebHostEnvironment _env;

        public DepartmentController( IUnitOfWork UintOfWork, IWebHostEnvironment env)
        {
           _uintOfWork = UintOfWork;
            //_departmentsRepo = departmentsRepo;
            _env = env;
        }
        public IActionResult Index()
        {
            var departments = _uintOfWork.DepartmentRepository.GetAll();
            return View(departments);
        }

        ////////////////////////////////////////////////////////////////
        public IActionResult Create()
        {
            return View();
        }

        ///////////////////////////////////////////////////////////////
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _uintOfWork.DepartmentRepository.Add(department);
                var count = _uintOfWork.Complete();
                if (count > 0)
                    return RedirectToAction(nameof(Index));

            }
            return View(department);

        }

        /// ///////////////////////////////////////////////////////////////

        //Department//Details/10
        //Department//Details
        [HttpGet]

        public IActionResult Details(int? id, string ViewName = "Details")
        {
            if (!id.HasValue)
                return BadRequest(); // 400

            var department = _uintOfWork.DepartmentRepository.Get(id.Value);
            _uintOfWork.Complete();

            if (department is null)
                return NotFound();


            return View(ViewName, department);
        }

        /// ///////////////////////////////////////////////////////////////

        //Department//Edit/10
        //Department//Edit
        [HttpGet]
        
        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");

            /*if (!id.HasValue)
                return BadRequest();

            var department = _departmentsRepo.Get(id.Value);

            if (department is null)
                return NotFound();


            return View(department);*/

        }

        /// ///////////////////////////////////////////////////////////

        //action filter ha nfz el end point wala laa m3 ay action m4 3ayz had ynfzo
        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Authorize]
        public IActionResult Edit([FromRoute] int id, Department department)
        {

            if (id != department.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
                return View(department);

            try
            {
                _uintOfWork.DepartmentRepository.Update(department);
                _uintOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                //log Exception
                if (_env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "Erorr has Occurred during update Department ");
                return View(department);
            }


        }
        /// ////////////////////////////////////////////////////////////

        //Department//Delete/10
        //Department//Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {

            return Details(id, "Delete");
        }


        /// /////////////////////////////////////////////////////////////

        [HttpPost]
        public IActionResult Delete(Department department)
        {
            _uintOfWork.DepartmentRepository.Delete(department);
            _uintOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }


    }
}
