using Demo_ASP.NET_MVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP.NET_MVC.BLL.Interfaces
{
    public interface IEmployeeRepository : IGenericsRepository<Employee>
    {
        IQueryable<Employee> GetEmployees(string address);
        IQueryable<Employee> SearcByhName(string name);

    }
}
