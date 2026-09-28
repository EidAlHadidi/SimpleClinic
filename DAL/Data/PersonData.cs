using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;

namespace DAL.Data
{
    public class PersonData
    {
        private readonly AppDbContext _context;

        public PersonData(AppDbContext context)
        {
            _context = context;
        }

        /*
        Because database operations are mostly I/O-bound: your program sends a query to SQL Server, 
        then waits for SQL Server to respond.
        Using async/await lets your thread do other work instead of sitting blocked during that wait.
        */
    }
}
