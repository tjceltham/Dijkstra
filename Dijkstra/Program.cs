using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {

            Node a = new Node("a", 0);
            Node b = new Node("b", 999);
            Node c = new Node("c", 999);
            Node d = new Node("d", 999);
            Node e = new Node("e", 999);
            Node f = new Node("f", 999);

            List<Node> pq = new List<Node>();
            pq.Add(a);
            pq.Add(b);
            pq.Add(c);
            pq.Add(d);
            pq.Add(e);
            // sort the priority q
            pq.OrderBy(x => x.distance);

            // Creating an ajacency matrix

            // List<Node> adj = new List<Node>[5];

            var adj = new Dictionary<string, Dictionary<string, int>>();
            var mapA1 = new Dictionary<string, int>();
            mapA1.Add("b", 7);
            mapA1.Add("d", 3);
            var mapB1 = new Dictionary<string, int>();
            mapB1.Add("a", 7);
            mapB1.Add("d", 2);
            mapB1.Add("c", 3);
            mapB1.Add("e", 6);

            var mapC1 = new Dictionary<string, int>();
            mapC1.Add("b", 3);
            mapC1.Add("d", 4);
            mapC1.Add("e", 1);

            var mapD1 = new Dictionary<string, int>();
            mapD1.Add("a", 3);
            mapD1.Add("b", 2);
            mapD1.Add("c", 4);
            mapD1.Add("e", 7);

            var mapE1 = new Dictionary<string, int>();
            mapE1.Add("c", 1);
            mapE1.Add("b", 6);
            mapE1.Add("d", 7);

            adj.Add("a", mapA1);
            adj.Add("b", mapB1);
            adj.Add("c", mapC1);
            adj.Add("d", mapD1);
            adj.Add("e", mapE1);

            Dijkstra(adj, pq);

            Console.WriteLine();
        }



        static void Dijkstra(Dictionary<string, Dictionary<string, int>> adj1, List<Node> pq)
        {
            List<Node> calculated = new List<Node>();
            Node current;
            Dictionary<string,int> dict;

            Dictionary<string, string> paths = new Dictionary<string,string>();
            paths.Add("a","-");
            paths.Add("b", "-");
            paths.Add("c", "-"); 
            paths.Add("d", "-"); 
            paths.Add("e", "-");


            while (pq.Count != 0)

            {
              

                 pq = pq.OrderBy(x => x.distance).ToList();

                current = pq[0];
                pq.RemoveAt(0);
                Console.WriteLine(current.name+ " " +current.distance);
                dict = adj1[current.name];

                foreach (KeyValuePair<string, int> item in dict)
                {
                   // Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);

                    if (qContains(pq,item.Key))
                    {
                        if (updateDistance(item.Key, current.distance + item.Value, pq))
                        {
                            paths[item.Key] = current.name;
                        }
                    }

                }
                calculated.Add(current);

            }

            foreach(Node  i in calculated) {
                Console.WriteLine("{0} =  {1}", i.name, i.distance);
            }
            foreach (KeyValuePair<string, string> item in paths)
            {
                Console.WriteLine(item.Key + "=>" + item.Value.ToString());
            }
            CalculatePath(paths);
        }



        static bool updateDistance(string n, int d, List<Node> q)
        {
            bool updated = false;
            foreach (Node item in q)
                {
                    if (item.name == n && d<item.distance)
                    {
                        item.distance = d;
                    updated = true;
                    }
                }
            return updated;
        }


        static bool qContains(List<Node> q, string n)
        {
            bool found = false;
            foreach (Node item in q)
            {
                if( item.name ==n)
                {
                    found = true;
                }
            }

                return found;
        }
        static void CalculatePath(Dictionary<string, string> p)
        {
            string dnode="";
            string node = "";
            string path = "";
            Stack<string> s = new Stack<string>();
            Console.WriteLine("Enter Node");
            dnode = Console.ReadLine();


            while (dnode != "a")
            {
                s.Push(dnode);
                dnode = p[dnode];

            }
            s.Push(dnode);
            while (s.Count()!=0)
            {
                path = path + s.Pop();
            }
            Console.WriteLine(path);


            
        }
    }
}



