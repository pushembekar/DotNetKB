﻿using System;
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

        public void InsertAtBeginning(int n)
        {
            Node p;
            Node temp = new Node(n);

            temp.Link = Start;
            Start = temp;
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
                //InsertAtBeginning(data);
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

        /// <summary>
        /// Find the reference to the last node of the list
        /// </summary>
        /// <returns></returns>
        public void FindLastNode()
        {
            var p = Start;

            while (p.Link != null)
                p = p.Link;

            Console.WriteLine($"Last element is {p.Info}");
        }

        public void FindSecondLastNode()
        {
            var p = Start;

            while (p.Link.Link != null)
                p = p.Link;

            Console.WriteLine($"Second Last element is {p.Info}");
        }

        public void FindElementWithValue(int x)
        {
            var p = Start;

            while (p != null)
            {
                if (p.Info == x)
                    break;
                p = p.Link;
            }

            var y = (p == null) ? "Not Found" : "Found";

            Console.WriteLine($"Element was {y} in the list");
        }

        public void Reverse()
        {
            Node p, prev, next;

            prev = null;
            p = Start;

            while(p != null)
            {
                next = p.Link;
                p.Link = prev;
                prev = p;
                p = next;
            }

            Start = prev;
            PrintList();
        }

        public void BubbleSort()
        {
            Node p, q, end;

            for(end = null; end != Start.Link; end = p)
            {
                for(p = Start; p.Link != end; p = p.Link)
                {
                    q = p.Link;
                    if (p.Info > q.Info)
                    {
                        int temp = p.Info;
                        p.Info = q.Info;
                        q.Info = temp;
                    }
                }
            }

            PrintList();
        }
    }
}
