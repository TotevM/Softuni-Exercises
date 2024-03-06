namespace Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var wordAndSyn = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                string word=Console.ReadLine();
                string synonym=Console.ReadLine();

                if (!wordAndSyn.ContainsKey(word))
                {
                    wordAndSyn[word] = synonym;
                }
                else
                {
                wordAndSyn[word] += ", " + synonym ;
                }
            }

            foreach (var item in wordAndSyn)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}