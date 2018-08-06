using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class SingleLinkedList
    {
        public Node Start { get; set; }

        public SingleLinkedList()
        {
            Start = null;
        }

        public void InsertAtEnd(int n)
        {
            Node p;
            Node temp = new Node(n);

            if (Start == null)
            {
                Start = temp;
                return;
            }

            p = Start;
            while (p.Link != null)
                p = p.Link;

            p.Link = temp;
        }

        public void CreateList()
        {
            int i, n, data;

            Console.WriteLine("Enter the number of nodes: ");
            n = Convert.ToInt32(Console.ReadLine());

            if (n == 0)
                return;

            for(i=1; i <= n; i++)
            {
                Console.Write("Enter the value of the element to be added : ");
                data = Convert.ToInt32(Console.ReadLine());
                InsertAtEnd(data);
            }
        }

        public void PrintList()
        {
            var p = Start;

            while(p != null)
            {
                Console.Write(p.Info + " ");
                p = p.Link;
            }
            Console.Write(Environment.NewLine);
        }

        public void Count()
        {
            var p = Start;
            int count = 0;

            while(p != null)
            {
                ++count;
                p = p.Link;
            }

            Console.WriteLine($"Count of elements: {count}");
        }
    }
}
