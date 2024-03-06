namespace Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> charOccurences = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char character = input[i];

                if (character == ' ')
                {
                    continue;
                }

                if (!charOccurences.ContainsKey(character))
                {
                    charOccurences.Add(character, 0);
                }

                charOccurences[character]++;
            }

            foreach (KeyValuePair<char, int> itemPair in charOccurences)
            {
                Console.WriteLine($"{itemPair.Key} -> {itemPair.Value}");
            }
        }
    }
}