﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Interfaces;
using WebDemo.Models.Context;

namespace WebApp.App_Start
{
    public class DbContextConfig
    {
        public static void Initialize(IConfiguration configuration, IWebHostEnvironment env, IServiceProvider svp)
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            if (env.IsDevelopment())
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
            else if (env.IsStaging())
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
            else if (env.IsProduction())
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
            var context = new ApplicationContext(optionsBuilder.Options);
            if (context.Database.EnsureCreated())
            {
                IUserMap service = svp.GetService(typeof(IUserMap)) as IUserMap;
                new DBInitializeConfig(service).DataTest();
            }

        }

        public static void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
