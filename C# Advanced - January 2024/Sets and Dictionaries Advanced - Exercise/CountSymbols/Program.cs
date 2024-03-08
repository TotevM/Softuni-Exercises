using System.Reflection.Metadata;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text=Console.ReadLine();
            SortedDictionary<char,int> occurrences = new SortedDictionary<char,int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!occurrences.ContainsKey(text[i]))
                {
                    occurrences[text[i]] = 0;
                }
                occurrences[text[i]]++;
            }
            foreach (var (character, count) in occurrences)
            {
                Console.WriteLine($"{character}: {count} time/s");
            }
        }
    }
}
