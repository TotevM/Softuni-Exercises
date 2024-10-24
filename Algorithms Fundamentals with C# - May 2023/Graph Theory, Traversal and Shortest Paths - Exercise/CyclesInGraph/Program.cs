using System;
using System.Collections.Generic;

public class Problem
{
    static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

    static HashSet<string> visited = new HashSet<string>();
    static HashSet<string> recStack = new HashSet<string>();

    static void AddEdge(string from, string to)
    {
        if (!graph.ContainsKey(from))
        {
            graph[from] = new List<string>();
        }
        graph[from].Add(to);
    }

    static bool DFS(string node)
    {
        visited.Add(node);
        recStack.Add(node);

        if (graph.ContainsKey(node))
        {
            foreach (var neighbor in graph[node])
            {
                if (!visited.Contains(neighbor))
                {
                    if (DFS(neighbor))
                    {
                        return true;
                    }
                }
                else if (recStack.Contains(neighbor))
                {
                    return true;
                }
            }
        }

        recStack.Remove(node);
        return false;
    }

    static void Main()
    {
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] parts = input.Split('-');
            string from = parts[0];
            string to = parts[1];
            AddEdge(from, to);
        }

        bool hasCycle = false;

        foreach (var node in graph.Keys)
        {
            if (!visited.Contains(node))
            {
                if (DFS(node))
                {
                    hasCycle = true;
                    break;
                }
            }
        }

        if (hasCycle)
        {
            Console.WriteLine("Acyclic: No");
        }
        else
        {
            Console.WriteLine("Acyclic: Yes");
        }
    }
}
