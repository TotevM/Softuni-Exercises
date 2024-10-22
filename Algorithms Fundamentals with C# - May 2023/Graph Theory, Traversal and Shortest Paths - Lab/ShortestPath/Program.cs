using System;
using System.Collections.Generic;

public class Problem
{
    static void Main(string[] args)
    {
        int nodes = int.Parse(Console.ReadLine());
        int edges = int.Parse(Console.ReadLine());

        List<int>[] graph = new List<int>[nodes + 1];
        for (int i = 1; i <= nodes; i++)
        {
            graph[i] = new List<int>();
        }

        for (int i = 0; i < edges; i++)
        {
            string[] edge = Console.ReadLine().Split();
            int u = int.Parse(edge[0]);
            int v = int.Parse(edge[1]);

            graph[u].Add(v);
            graph[v].Add(u);
        }

        int startNode = int.Parse(Console.ReadLine());
        int endNode = int.Parse(Console.ReadLine());

        var result = BFS(graph, startNode, endNode);

        if (result != null)
        {
            Console.WriteLine("Shortest path length is: " + (result.Count - 1));
            Console.WriteLine(string.Join(" ", result));
        }
        else
        {
            Console.WriteLine("No path found");
        }
    }

    static List<int> BFS(List<int>[] graph, int start, int end)
    {
        bool[] visited = new bool[graph.Length];
        int[] previous = new int[graph.Length];

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        visited[start] = true;
        previous[start] = -1;

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();

            if (node == end)
            {
                return ConstructPath(previous, start, end);
            }

            foreach (int neighbor in graph[node])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                    previous[neighbor] = node;
                }
            }
        }

        return null;
    }

    static List<int> ConstructPath(int[] previous, int start, int end)
    {
        List<int> path = new List<int>();
        for (int at = end; at != -1; at = previous[at])
        {
            path.Add(at);
        }
        path.Reverse();
        return path;
    }
}
