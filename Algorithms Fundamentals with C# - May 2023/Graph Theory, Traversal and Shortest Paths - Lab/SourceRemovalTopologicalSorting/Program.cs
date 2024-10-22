using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        // Input number of nodes
        int n = int.Parse(Console.ReadLine());

        // Graph and in-degree dictionary initialization
        Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        Dictionary<string, int> inDegree = new Dictionary<string, int>();

        // Read input edges and construct the graph
        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            var parts = line.Split(" -> ");
            string key = parts[0].Trim();

            if (!graph.ContainsKey(key))
            {
                graph[key] = new List<string>();
                inDegree[key] = 0;
            }

            if (parts.Length > 1 && !string.IsNullOrEmpty(parts[1]))
            {
                string[] children = parts[1].Split(", ");
                foreach (string child in children)
                {
                    if (!graph.ContainsKey(child))
                    {
                        graph[child] = new List<string>();
                        inDegree[child] = 0;
                    }

                    graph[key].Add(child);
                    inDegree[child]++;
                }
            }
        }

        // List to keep the sorted nodes
        List<string> sortedOrder = new List<string>();

        // Queue for nodes with zero in-degree (sources)
        Queue<string> sources = new Queue<string>();
        foreach (var node in inDegree)
        {
            if (node.Value == 0)
            {
                sources.Enqueue(node.Key);
            }
        }

        // Process the graph
        while (sources.Count > 0)
        {
            string source = sources.Dequeue();
            sortedOrder.Add(source);

            foreach (var child in graph[source])
            {
                inDegree[child]--;
                if (inDegree[child] == 0)
                {
                    sources.Enqueue(child);
                }
            }
        }

        // Check if sorting is valid (all nodes should be sorted)
        if (sortedOrder.Count == inDegree.Count)
        {
            Console.WriteLine("Topological sorting: " + string.Join(", ", sortedOrder));
        }
        else
        {
            Console.WriteLine("Invalid topological sorting");
        }
    }
}
