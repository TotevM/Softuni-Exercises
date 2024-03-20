using System.Collections.ObjectModel;
using System.Text;

namespace Cards
{
    internal class Card
    {
        private readonly List<string> faces = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private readonly List<string> suits = new List<string> { "S", "H", "D", "C" };

        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face
        {
            get => face;
            private set
            {
                if (!faces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                face = value;
            }
        }
        public string Suit
        {
            get => suit;
            private set
            {
                if (!suits.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                suit = value;
            }
        }

        public override string ToString()
        {
            byte[] bytes;
            string suitToAppend;
            StringBuilder sb = new();
            sb.Append($"[{face}");
            switch (suit)
            {
                case "S":
                    bytes = Encoding.UTF8.GetBytes("\u2660");
                    suitToAppend = Encoding.UTF8.GetString(bytes);
                    sb.Append($"{suitToAppend}]");
                    break;
                case "H":
                    bytes = Encoding.UTF8.GetBytes("\u2665");
                    suitToAppend = Encoding.UTF8.GetString(bytes);
                    sb.Append($"{suitToAppend}]");
                    break;
                case "D":
                    bytes = Encoding.UTF8.GetBytes("\u2666");
                    suitToAppend = Encoding.UTF8.GetString(bytes);
                    sb.Append($"{suitToAppend}]");
                    break;
                case "C":
                    bytes = Encoding.UTF8.GetBytes("\u2663");
                    suitToAppend = Encoding.UTF8.GetString(bytes);
                    sb.Append($"{suitToAppend}]");
                    break;
            }
            return sb.ToString().TrimEnd();
        }
    }
}
