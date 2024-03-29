using Demo_ASP.NET_MVC.BLL.Interfaces;
using Demo_ASP.NET_MVC.DAL.Models;
using Demo_ASP.NET_MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP.NET_MVC.BLL.Repositories
{
    public class DepartmentRepository : GenericsRepository<Department>, IDepartmentRepository
    {   //Object member 
        public DepartmentRepository(ApplicationDbContext dbContext)
             : base(dbContext)
        {

        }

    }
}
