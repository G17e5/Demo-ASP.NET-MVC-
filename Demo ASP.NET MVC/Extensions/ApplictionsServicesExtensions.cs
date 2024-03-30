using Demo_ASP.NET_MVC.BLL.Interfaces;
using Demo_ASP.NET_MVC.BLL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Demo_ASP.NET_MVC.Extensions
{
    public static class ApplictionsServicesExtensions
    {
        public static void AddApplictionServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IEmployeeRepository , EmployeeRepository>();
        }

    }
}
