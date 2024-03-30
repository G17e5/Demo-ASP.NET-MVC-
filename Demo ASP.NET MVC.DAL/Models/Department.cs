using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP.NET_MVC.DAL.Models
{
    public class Department :ModelBase
    {
        public string Code { get; set; }
        //[Required]
        public string Name { get; set; }// Option => ASP.NET Core 5
        [Display(Name = "Date Of Creation")]
        public DateTime DateOfCreation { get; set; }


       // [InverseProperty(nameof(Models.Department.Employees))]
        //Navgtion propperty ==> Many
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
