namespace A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string, int> resourcesMap = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "stop")
            {
                if (!resourcesMap.ContainsKey(input))
                {
                    resourcesMap.Add(input, 0);
                }

                int quantity = int.Parse(Console.ReadLine());
                resourcesMap[input] += quantity;
            }

            foreach (KeyValuePair<string, int> itemPair in resourcesMap)
            {
                Console.WriteLine($"{itemPair.Key} -> {itemPair.Value}");
            }
        }
    }
}