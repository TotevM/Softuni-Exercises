using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        Dictionary<string, int> inDegree = new Dictionary<string, int>();

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            var parts = line.Split(" ->");
            string key = parts[0].Trim();

            if (!graph.ContainsKey(key))
            {
                graph[key] = new List<string>();
                inDegree[key] = 0;
            }

            if (parts.Length > 1 && !string.IsNullOrEmpty(parts[1]))
            {
                string[] children = parts[1].Trim().Split(", ");
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
            else
            {
                graph[key] = new();
            }
        }

        List<string> sortedOrder = new List<string>();

        Queue<string> sources = new Queue<string>();
        foreach (var node in inDegree)
        {
            if (node.Value == 0)
            {
                sources.Enqueue(node.Key);
            }
        }

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