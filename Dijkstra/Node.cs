using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra
{
    class Node

    {
        public int distance;
        public string name;
        public Node(string n, int d)
        {
            name = n;
            distance = d;

        }
       
    }
}
