namespace VariationsWithRepetition
{
    internal class Program
    {
        private static string[] arr;
        static void Main(string[] args)
        {

            string[] arr = Console.ReadLine().Split().ToArray();
            int k = int.Parse(Console.ReadLine());

            List<string> variations = new List<string>();
            FindVariations(arr, k, "");
        }

        static void FindVariations(string[] elements, int k, string current)
        {
            if (current.Length == k)
            {
                Console.WriteLine(current);
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                FindVariations(elements, k, current + elements[i]);
            }
        }
    }
}

