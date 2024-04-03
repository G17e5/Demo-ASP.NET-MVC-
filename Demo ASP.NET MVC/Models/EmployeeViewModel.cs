using Demo_ASP.NET_MVC.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace Demo_ASP.NET_MVC.Models
{
    public class EmployeeViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }
        [Range(22, 30)]
        public int? Age { get; set; }
        public string Address { get; set; }

        [DataType(DataType.Currency)]
        public int Salary { get; set; }

        [Display(Name = "IS Active")]
        public bool Isactive { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "phone Number")]
        public string phone { get; set; }

        public DateTime HireDate { get; set; }

        public Gender Gender { get; set; }
        public EmpType EmployeType { get; set; }

        public int? DepartmentId { get; set; }// forgin key column
        //Navgtion propperty ==> one
        public Department Department { get; set; }
        public IFormFile Image { get; set; }

        public string ImageName  { get; set; }
    }
}
