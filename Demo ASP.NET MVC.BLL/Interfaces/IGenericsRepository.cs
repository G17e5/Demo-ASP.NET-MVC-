using Demo_ASP.NET_MVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP.NET_MVC.BLL.Interfaces
{
    public interface IGenericsRepository<T> where T : ModelBase // IN DAL IN MODULES MAKE CLAS NAMED MODEL BASE 
    {
        IEnumerable<T> GetAll();
        T Get(int id);

        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);


    }
}
