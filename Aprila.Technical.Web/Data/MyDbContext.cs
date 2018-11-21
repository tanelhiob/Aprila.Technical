using Aprila.Technical.Web.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
