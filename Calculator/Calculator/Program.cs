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
                    case 3:
                        Multiply();
                        break;
                    case 4:
                        Divide();
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
            Console.WriteLine("Enter first number:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number:");
            int b = Convert.ToInt32(Console.ReadLine());
            // add the numbers
            int c = a + b;
            Console.WriteLine("Result is " + c.ToString() + "\n");
        }

        private static void Subtract()
        {
            Console.WriteLine("Enter first number:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number:");
            int b = Convert.ToInt32(Console.ReadLine());
            // add the numbers
            int c = a - b;
            Console.WriteLine("Result is " + c.ToString() + "\n");
        }

        private static void Multiply()
        {
            Console.WriteLine("Enter first number:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number:");
            int b = Convert.ToInt32(Console.ReadLine());
            // add the numbers
            int c = a * b;
            Console.WriteLine("Result is " + c.ToString() + "\n");
        }

        private static void Divide()
        {
            throw new NotImplementedException();
        }
    }
}
