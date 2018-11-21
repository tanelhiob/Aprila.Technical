using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aprila.Technical.Web.Data;
using Aprila.Technical.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Aprila.Technical.Web
{
    public class Startup
    {
       public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = "Data Source=|DataDirectory|\\Aprila.Technical.sqlite;";
            services.AddDbContextPool<MyDbContext>(opt => opt.UseSqlite(connectionString));

            services.AddSingleton<ICalculator, Calculator>(serviceProvider => new Calculator(connectionString));
       }

        public void Configure(IApplicationBuilder app, ICalculator calculator)
        {
            app.UseDeveloperExceptionPage();

            app.Run(async (context) =>
            {
                var query = context.Request.QueryString;
                var queryDictionary = QueryHelpers.ParseNullableQuery(query.ToUriComponent());
                var a = 1; //int.Parse(queryDictionary["a"]);
                var b = 2; //int.Parse(queryDictionary["b"]);
                var c = calculator.Add(a, b);
                await context.Response.WriteAsync(c.ToString());
            });
        }
    }
}
