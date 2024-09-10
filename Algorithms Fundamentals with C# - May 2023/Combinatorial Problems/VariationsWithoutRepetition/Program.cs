namespace VariationsWithoutRepetition
{
    internal class Program
    {
        private static string[] arr;
        static void Main(string[] args)
        {
            
            string[] arr = Console.ReadLine().Split().ToArray();
            int k = int.Parse(Console.ReadLine());

            List<string> variations = new List<string>();
            FindVariations(arr, k, "", new bool[arr.Length]);
        }

        static void FindVariations(string[] elements, int k, string current, bool[] used)
        {
            if (current.Length == k)
            {
                Console.WriteLine(current);
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    FindVariations(elements, k, current + elements[i], used);
                    used[i] = false;
                }
            }
        }
    }
}
