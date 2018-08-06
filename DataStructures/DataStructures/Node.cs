using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class Node
    {
        public int Info { get; set;  }
        public Node Link { get; set; }

        public Node(int info)
        {
            Info = info;
            Link = null;
        }

        public Node(int info, Node link)
        {
            Info = info;
            Link = link;
        }
    }
}
