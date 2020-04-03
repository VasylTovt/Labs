using System;
using System.Text;
using vflibcs;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph1 = new Graph();
            graph1.InsertNodes(5);
            graph1.InsertEdge(0, 2);
            graph1.InsertEdge(2, 4);
            graph1.InsertEdge(4, 1);
            graph1.InsertEdge(1, 3);
            graph1.InsertEdge(3, 0);

            var graph2 = new Graph();
            graph2.InsertNodes(5);
            graph2.InsertEdge(0, 1);
            graph2.InsertEdge(1, 4);
            graph2.InsertEdge(4, 3);
            graph2.InsertEdge(3, 2);
            graph2.InsertEdge(2, 0);

            var vfs = new VfState(graph1, graph2, false);
            var match = vfs.FMatch();
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(match ? "Графи ізоморфні" : "Графи не ізоморфні");
            if (match)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(i + " -> " + vfs.Mapping1To2[i]);
                }
            }
            Console.ReadKey();
        }
    }
}
