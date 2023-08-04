using App.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Webapi.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using(var servisScope = app.ApplicationServices.CreateScope())
            {
                servisScope.ServiceProvider.GetService<AppDataContext>().Database.Migrate();
            }
        }

    }
}
