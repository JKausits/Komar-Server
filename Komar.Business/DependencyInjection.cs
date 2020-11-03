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
            return services;
        }
    }
}
