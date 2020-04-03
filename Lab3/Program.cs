using System;
using System.Collections.Generic;
using System.Text;

public class MaxFlow
{
    public static void Main()
    {
        int[,] graph = { {0, 5, 4, 0, 0, 0},
                {0, 0, 3, 5, 3, 0},
                {0, 0, 0, 8, 2, 0},
                {0, 0, 0, 0, 6, 4},
                {0, 0, 0, 0, 0, 5},
                {0, 0, 0, 0, 0, 0}
            };

        var m = new MaxFlow();

        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Максимальний потік " +
                          m.FordFulkerson(graph, 0, 5));

        Console.ReadKey();

    }

    private int FordFulkerson(int[,] graph, int s, int t)
    {
        int u, v;

        int[,] rGraph = new int[V, V];

        for (u = 0; u < V; u++)
            for (v = 0; v < V; v++)
                rGraph[u, v] = graph[u, v];

        int[] parent = new int[V];

        int maxFlow = 0;

        while (Bfs(rGraph, s, t, parent))
        {
            var pathFlow = int.MaxValue;
            for (v = t; v != s; v = parent[v])
            {
                u = parent[v];
                pathFlow = Math.Min(pathFlow, rGraph[u, v]);
            }

            for (v = t; v != s; v = parent[v])
            {
                u = parent[v];
                rGraph[u, v] -= pathFlow;
                rGraph[v, u] += pathFlow;
            }

            maxFlow += pathFlow;
        }

        return maxFlow;
    }

    private const int V = 6;

    private static bool Bfs(int[,] rGraph, int s, int t, IList<int> parent)
    {
        var visited = new bool[V];
        for (var i = 0; i < V; ++i)
            visited[i] = false;

        var queue = new List<int>
            {
                s
            };

        visited[s] = true;
        parent[s] = -1;

        while (queue.Count != 0)
        {
            var u = queue[0];
            queue.RemoveAt(0);

            for (var v = 0; v < V; v++)
            {
                if (visited[v] != false || rGraph[u, v] <= 0) continue;
                queue.Add(v);
                parent[v] = u;
                visited[v] = true;
            }
        }

        return visited[t];
    }
}