namespace Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();
            string[] cardsTokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < cardsTokens.Length; i++)
            {
                try
                {
                    string[] currCardTokens = cardsTokens[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string currCardFace = currCardTokens[0];
                    string currCardValue = currCardTokens[1];
                    cards.Add(new Card(currCardFace, currCardValue));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            Console.WriteLine(String.Join(' ', cards));
        }
    }
}
