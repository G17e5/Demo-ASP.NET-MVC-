using Demo_ASP.NET_MVC.BLL.Interfaces;
using Demo_ASP.NET_MVC.DAL.Models;
using Demo_ASP.NET_MVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Demo_ASP.NET_MVC.BLL.Repositories
{
    public class GenericsRepository<T> : IGenericsRepository<T> where T : ModelBase
    {
        private protected readonly ApplicationDbContext _dbcontext;
        public GenericsRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public int Add(T entity)
        {
            _dbcontext.Set<T>().Add(entity);
            return _dbcontext.SaveChanges();
        }

        public int Update(T entity)
        {
            _dbcontext.Set<T>().Update(entity);
            return _dbcontext.SaveChanges();
        }

        public int Delete(T entity)
        {
            _dbcontext.Set<T>().Remove(entity);
            return _dbcontext.SaveChanges();
        }

        public T Get(int id)
        {
            return _dbcontext.Find<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            if(typeof(T) == typeof(Employee))
                return (IEnumerable<T>) _dbcontext.Employees.Include(E => E.Department).AsNoTracking().ToList();
            else
                return _dbcontext.Set<T>().AsNoTracking().ToList();
          
        }
            
    }
}
