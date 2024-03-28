using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}
