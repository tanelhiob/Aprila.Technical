using Aprila.Technical.Web.Data;
using Aprila.Technical.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using System.Linq;
using System.Text;

namespace Aprila.Technical.Web
{
    public class Startup
    {
       public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = "Data Source=MyDatabase.db";
            services.AddDbContextPool<MyDbContext>(opt => opt.UseSqlite(connectionString));

            services.AddSingleton<ICalculator, Calculator>(serviceProvider => new Calculator(connectionString));
       }

        public void Configure(IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.CreateScope())
            {
                scope.ServiceProvider.GetService<MyDbContext>().Database.Migrate();
            }
 
            app.UseDeveloperExceptionPage();

            app.Run(async (context) =>
            {
                var responseMessage = new StringBuilder();
                responseMessage.AppendLine(":P");
                
                var query = context.Request.Query;

                if (query.TryGetValue("name", out StringValues name))
                {
                    var db = context.RequestServices.GetService<MyDbContext>();
                    db.Add(new Domain.User { Id = System.Guid.NewGuid(), Name = name });
                    await db.SaveChangesAsync();
                }

                if (query.TryGetValue("a", out StringValues a) && query.TryGetValue("b", out StringValues b))
                {
                    var calculator = context.RequestServices.GetService<ICalculator>();
                    var c = calculator.Add(int.Parse(a.First()), int.Parse(b.First()));
                    responseMessage.AppendLine(c.ToString());
                }

                await context.Response.WriteAsync(responseMessage.ToString());
            });
        }
    }
}
