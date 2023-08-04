using App.Application.Common.Helpers;
using App.Application.Common.Interfaces;
using App.Application.TodoService.Command;
using App.Application.UserService.Commond;
using App.Application.WorkblogService.Command;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreApplication(this IServiceCollection services)
        {
            services.AddScoped<ITodo, TodoCommandService>();
            services.AddScoped<IUser, UserCommandService>();
            services.AddScoped<IHash, Hash>();
            services.AddScoped<IBlog, WorkblogCommandService>();
            return services;
        }
    }
}
