using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace MySQLDBConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MySqlDbContext())
            {
                var customers = context.Customer.Count();
                Console.WriteLine("Customers = " + customers);
            }
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
