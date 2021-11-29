using Microsoft.Extensions.DependencyInjection;
using WebApp.Interfaces;
using WebDemo.Maps;
using WebDemo.Models.Context;
using WebDemo.Repositories;
using WebDemo.Services;

namespace WebApp.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void AddScope(IServiceCollection services)
        {
            services.AddScoped<IApplicationContext, ApplicationContext>();
            services.AddScoped<IUserMap, UserMap>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IStudentsMap, StudentsMap>();
            services.AddScoped<IStudentsRepository, StudentsRepository>();
            services.AddScoped<IStudentsService, StudentsService>();
        }
    }
}
