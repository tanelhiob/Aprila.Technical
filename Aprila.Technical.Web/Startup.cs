using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aprila.Technical.Web.Data;
using Aprila.Technical.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Aprila.Technical.Web
{
    public class Startup
    {
       public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICalculator, Calculator>();

            var connectionString = "";
            // services.AddDbContext<MyDbContext>(opt => opt.UseSqlite(connectionString));
        }

        public void Configure(IApplicationBuilder app, ICalculator calculator)
        {
            app.Run(async (request) => await Task.FromResult("Hello, world"));
        }
    }
}
