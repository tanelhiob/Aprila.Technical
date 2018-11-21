using Aprila.Technical.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Aprila.Technical.Web.Services
{
    public class Calculator : ICalculator
    {
        //private readonly IServiceProvider _services;

        //public Calculator(IServiceProvider services) 
        //{
        //    _services = services;
        //}

        private readonly string _connectionString;

        public Calculator(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Add(int a, int b)
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseSqlite(_connectionString)
                .Options;

            using (var db = new MyDbContext(options))
            {
                return a + b + (db.Users.FirstOrDefault()?.Name.Length ?? 0);
            }
        }
    }
}
