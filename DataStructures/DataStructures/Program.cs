using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SingleLinkedList list = new SingleLinkedList();
            list.CreateList();
            Console.Write("*********************************" + Environment.NewLine);
            list.PrintList();
            Console.Write("*********************************" + Environment.NewLine);
            list.Count();
            Console.Write("*********************************" + Environment.NewLine);
            list.FindLastNode();
            Console.Write("*********************************" + Environment.NewLine);
            list.FindSecondLastNode();
            Console.Write("*********************************" + Environment.NewLine);
            list.FindElementWithValue(50);
            Console.Write("*********************************" + Environment.NewLine);
            list.Reverse();
            Console.Write("*********************************" + Environment.NewLine);
            list.BubbleSort();
            Console.Write("*********************************" + Environment.NewLine);
            Console.Read();
        }
    }
}
