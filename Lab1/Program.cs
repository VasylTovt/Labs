using System;
using System.Text;

class MST
{
    public static void Main()
    {
        int[,] graph = new int[,]
        {
            {0, 1, 0, 15, 0, 0},
            { 1, 0, 5, 9, 0, 0},
            { 0, 5, 0, 4, 4, 3},
            { 15, 9, 4, 0, 2, 0},
            { 0, 0, 4, 2, 0, 11 },
            { 0, 0, 3, 0, 11, 0 }
        };


        PrimMST(graph);
    }
    
    static int MinKey(int[] key, bool[] mstSet, int V)
    {
        int min = int.MaxValue, min_index = -1;

        for (int v = 0; v < V; v++)
            if (mstSet[v] == false && key[v] < min)
            {
                min = key[v];
                min_index = v;
            }

        return min_index;
    }
    
    static void PrintMST(int[] parent, int[,] graph, int V)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Ребро \tВага");
        for (int i = 1; i < V; i++)
            Console.WriteLine(parent[i] + " - " + i + "\t" + graph[i, parent[i]]);
        Console.ReadKey();
    }
    
    static void PrimMST(int[,] graph)
    {
        var V = graph.GetLength(0);

        int[] parent = new int[V];
        int[] key = new int[V];
        bool[] mstSet = new bool[V];
        
        for (int i = 0; i < V; i++)
        {
            key[i] = int.MaxValue;
            mstSet[i] = false;
        }
        
        key[0] = 0;
        parent[0] = -1;
        
        for (int count = 0; count < V - 1; count++)
        {
            int u = MinKey(key, mstSet, V);
            mstSet[u] = true;
            
            for (int v = 0; v < V; v++)
                if (graph[u, v] != 0 && mstSet[v] == false
                    && graph[u, v] < key[v])
                {
                    parent[v] = u;
                    key[v] = graph[u, v];
                }
        }
        
        PrintMST(parent, graph, V);
    }
}