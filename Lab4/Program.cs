﻿using System;

class GFG
{
    static void Main()
    {
        int n = 4;

        int[,] graph = {
            { 0, 5, 2, 4 },
            { 5, 0, 4, 5 },
            { 2, 4, 0, 6 },
            { 4, 5, 6, 0 }
        };

        bool[] v = new bool[n];
        v[0] = true;
        int ans = int.MaxValue;

        ans = tsp(graph, v, 0, n, 1, 0, ans);

        Console.Write(ans);
        Console.ReadKey();
    }

    static int tsp(int[,] graph, bool[] v, int currPos,
        int n, int count, int cost, int ans)
    {
        if (count == n && graph[currPos, 0] > 0)
        {
            ans = Math.Min(ans, cost + graph[currPos, 0]);
            return ans;
        }

        for (int i = 0; i < n; i++)
        {
            if (v[i] == false && graph[currPos, i] > 0)
            {
                v[i] = true;
                ans = tsp(graph, v, i, n, count + 1,
                    cost + graph[currPos, i], ans);

                v[i] = false;
            }
        }
        return ans;
    }
}
