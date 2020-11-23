using AutoMapper;
using Komar.Business.Implementations;
using Komar.Shared.Interfaces.Business;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Komar.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<ICategoryBusiness, CategoryBusiness>();
            services.AddTransient<IBrandBusiness, BrandBusiness>();
            services.AddTransient<IMaterialBusiness, MaterialBusiness>();
            services.AddTransient<IEmployeeTypeBusiness, EmployeeTypeBusiness>();
            services.AddTransient<IEmployeeRateBusiness, EmployeeRateBusiness>();
            return services;
        }
    }
}
