using Demo_ASP.NET_MVC.BLL.Interfaces;
using Demo_ASP.NET_MVC.DAL.Models;
using Demo_ASP.NET_MVC.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP.NET_MVC.BLL.Repositories
{
    public class EmployeeRepository : GenericsRepository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            //_dbContext = dbContext;
        }


        //object Member
        public IQueryable<Employee> GetEmployees(string address)
        {
            return _dbcontext.Employees.Where(e => e.Address.ToLower() == address.ToLower());
        }

        public IQueryable<Employee> SearcByhName(string name)
        => _dbcontext.Employees.Where(E => E.Name.ToLower().Contains(name));
         
    }

}
