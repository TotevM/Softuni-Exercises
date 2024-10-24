using System;
using System.Collections.Generic;

public class Problem
{
    private static List<int>[] graph;
    private static bool[] visited;
    private static int[] discoveryTime, lowTime, parent;
    private static List<Tuple<int, int>> importantStreets;
    private static int time;

    public static void Main()
    {
        int buildings = int.Parse(Console.ReadLine());
        int streets = int.Parse(Console.ReadLine());

        graph = new List<int>[buildings];
        for (int i = 0; i < buildings; i++)
        {
            graph[i] = new List<int>();
        }

        for (int i = 0; i < streets; i++)
        {
            var input = Console.ReadLine().Split(" - ");
            int u = int.Parse(input[0]);
            int v = int.Parse(input[1]);
            graph[u].Add(v);
            graph[v].Add(u);
        }

        visited = new bool[buildings];
        discoveryTime = new int[buildings];
        lowTime = new int[buildings];
        parent = new int[buildings];
        importantStreets = new List<Tuple<int, int>>();
        time = 0;

        for (int i = 0; i < buildings; i++)
        {
            parent[i] = -1;
        }

        for (int i = 0; i < buildings; i++)
        {
            if (!visited[i])
            {
                DFS(i);
            }
        }

        Console.WriteLine("Important streets:");
        foreach (var street in importantStreets)
        {
            Console.WriteLine($"{street.Item1} {street.Item2}");
        }
    }

    private static void DFS(int u)
    {
        visited[u] = true;
        discoveryTime[u] = lowTime[u] = ++time;

        foreach (var v in graph[u])
        {
            if (!visited[v])
            {
                parent[v] = u;
                DFS(v);

                lowTime[u] = Math.Min(lowTime[u], lowTime[v]);

                if (lowTime[v] > discoveryTime[u])
                {
                    importantStreets.Add(new Tuple<int, int>(Math.Min(u, v), Math.Max(u, v)));
                }
            }
            else if (v != parent[u])
            {
                lowTime[u] = Math.Min(lowTime[u], discoveryTime[v]);
            }
        }
    }
}
