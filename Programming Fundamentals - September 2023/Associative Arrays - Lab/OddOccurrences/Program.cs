namespace Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split()
                .Select(x => x.ToLower())
                .ToArray();

            var wordOccurences = new Dictionary<string, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!wordOccurences.ContainsKey(numbers[i]))
                {
                    wordOccurences[numbers[i]] = 0;
                }
                wordOccurences[numbers[i]]++;
            }

            foreach (var item in wordOccurences)
            {
                if (item.Value % 2 == 1)
                {
                Console.Write(item.Key+" ");
                }
            }
        }
    }
}