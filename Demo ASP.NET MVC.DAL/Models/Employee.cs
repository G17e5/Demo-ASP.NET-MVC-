using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP.NET_MVC.DAL.Models
{
    public enum Gender
    {
        [EnumMember(Value = "Male")]
        Male = 1,

        [EnumMember(Value = "Female")]
        Female = 2,
    }

    public enum EmpType
    {
        FullTime = 1,
        PartTime = 2
    }
    public class Employee : ModelBase
    {

        #region Data
        public int MyProperty { get; set; }
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
        #endregion


        public string ImageName { get; set; }

        public int? DepartmentId { get; set; }// forgin key column
        //Navgtion propperty ==> one
        public Department Department { get; set; }

    }
}
