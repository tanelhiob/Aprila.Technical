using Aprila.Technical.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aprila.Technical.Web.Services
{
    public class Calculator : ICalculator
    {
        private readonly MyDbContext _db;

        public Calculator(MyDbContext db)
        {
            _db = db;
        }

        public int Add(int a, int b)
        {
            return a + b + (_db.Users.FirstOrDefault()?.Name.Length ?? 0);
        }
    }
}
