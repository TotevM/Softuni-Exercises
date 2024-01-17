namespace Toy_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double cena = double.Parse(Console.ReadLine());
            int puzel = int.Parse(Console.ReadLine());
            int kukla = int.Parse(Console.ReadLine());
            int mechka = int.Parse(Console.ReadLine());
            int minion = int.Parse(Console.ReadLine());
            int kamion = int.Parse(Console.ReadLine());

            double puzelCena = 2.60;
            double kuklaCena = 3.0;
            double mechkaCena = 4.10;
            double minionCena = 8.20;
            double kamionCena = 2.0;

            int br = puzel + kukla + mechka + minion + kamion;
            double price = puzelCena * puzel + mechkaCena * mechka + kuklaCena * kukla + minionCena * minion + kamionCena * kamion;
            if (br >= 50) { price *= 0.75; }
            price *= 0.9;
            if (price >= cena) { Console.WriteLine($"Yes! {price - cena:F2} lv left."); }
            else { Console.WriteLine($"Not enough money! {cena - price:F2} lv needed."); }
        }
    }
}