using EmployeeManagement.Core.IServices;
using EmployeeManagement.Core.IRepositories;
using EmployeeManagement.Resources.Repositories;
using EmployeeManagement.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeManagement.Utilities
{
    public class DIResolver
    {
        #region Context
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            #endregion
            #region Services

            services.AddScoped<IEmployeeService, EmployeeService>();

            #endregion
            #region Repository

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            #endregion

        }
    }
}
