namespace CombinationsWithRepetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split().ToArray();
            int k = int.Parse(Console.ReadLine());

            FindCombinations(elements, k, 0, "");
        }

        static void FindCombinations(string[] elements, int k, int start, string current)
        {
            if (current.Length == k)
            {
                Console.WriteLine(current);
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                FindCombinations(elements, k, i, current + elements[i]);
            }
        }
    }
}


