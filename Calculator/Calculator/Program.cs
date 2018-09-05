using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            const int EXITCODE = 99;
            while (true)
            {
                Console.WriteLine("Press " + EXITCODE + " to escape");
                Console.WriteLine("What mathematical operation would you like to do?");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                int option = Convert.ToInt32(Console.ReadLine());
            
                switch (option)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Subtract();
                        break;
                    case 99:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid operation\n");
                        break;
                }
            }
        }

        private static void Add()
        {
            throw new NotImplementedException();
        }

        private static void Subtract()
        {
            throw new NotImplementedException();
        }
    }
}
