public class Program
{
    static int BFS(Dictionary<int, List<int>> graph, int start, int end)
    {
        if (start == end) return 0;

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);

        Dictionary<int, int> distances = new Dictionary<int, int>();
        distances[start] = 0;

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();

            foreach (int neighbor in graph[node])
            {
                if (!distances.ContainsKey(neighbor))
                {
                    distances[neighbor] = distances[node] + 1;
                    queue.Enqueue(neighbor);

                    if (neighbor == end) return distances[neighbor];
                }
            }
        }
        return -1;
    }

    static void Main()
    {
        int numberOfLines = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();


        for (int i = 1; i <= numberOfLines; i++)
        {
            graph[i] = new List<int>();
            string[] edgeInput = Console.ReadLine().Split(":");
            int from = int.Parse(edgeInput[0]);

            if (edgeInput.Length > 1 && !string.IsNullOrEmpty(edgeInput[1]))
            {
                string[] toNodes = edgeInput[1].Split(' ');
                foreach (var toNode in toNodes)
                {
                    graph[from].Add(int.Parse(toNode));
                }
            }
        }

        for (int i = 0; i < p; i++)
        {
            string[] pair = Console.ReadLine().Split('-');
            int start = int.Parse(pair[0]);
            int end = int.Parse(pair[1]);

            int result = BFS(graph, start, end);
            Console.WriteLine($"{{{start}, {end}}} -> {result}");
        }
    }
}
