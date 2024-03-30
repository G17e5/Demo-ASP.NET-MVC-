using AutoMapper;
using Demo_ASP.NET_MVC.DAL.Models;
using Demo_ASP.NET_MVC.Models;

namespace Demo_ASP.NET_MVC.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
         
        }
    }
}
