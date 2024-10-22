using System;
using System.Collections.Generic;

public class Program
{
    private static List<int>[] graph;
    private static bool[] visited;
    static void Main()
    {
        graph = ReadGraph();
        FindGraphConnectedComponents();
    }

    private static void FindGraphConnectedComponents()
    {
        visited = new bool[graph.Length];

        for (int startNode = 0; startNode < graph.Length; startNode++)
        {
            if (!visited[startNode])
            {
                Console.Write("Connected component: ");
                DFS(startNode);
                Console.WriteLine();
            }
        }
    }

    private static List<int>[] ReadGraph()
    {
        int n = int.Parse(Console.ReadLine());
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }

        return graph;
    }

    static void DFS(int node)
    {
        visited[node] = true;

        foreach (var neighbor in graph[node])
        {
            if (!visited[neighbor])
            {
                DFS(neighbor);
            }
        }

        Console.Write(" " + node);
    }
}