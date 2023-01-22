using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.InfraIoc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //App Layer
            services.AddScoped<ICourseServices, CourseServices>();
            services.AddScoped<IUserServices, UserServices>();

            //Data Layer
            services.AddScoped<ICourseRepository,CourseRepository>();
            services.AddScoped<IUserRepository ,UserRepository>();
        }
    }
}
