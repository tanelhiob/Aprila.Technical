using Aprila.Technical.Web.Domain;
using Microsoft.EntityFrameworkCore;

namespace Aprila.Technical.Web.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            :base(options)
        {

        }
    }
}
