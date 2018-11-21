using Aprila.Technical.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Aprila.Technical.Web.Services
{
    public class Calculator : ICalculator
    {
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
                return a + b + (db.Users.LastOrDefault()?.Name.Length ?? 0);
            }
        }
    }
}
