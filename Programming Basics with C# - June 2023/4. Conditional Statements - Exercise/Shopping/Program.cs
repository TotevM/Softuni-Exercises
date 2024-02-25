namespace Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int videoKarti = int.Parse(Console.ReadLine());
            int cpu = int.Parse(Console.ReadLine());
            int ram = int.Parse(Console.ReadLine());

            double cenaVideoKarti = videoKarti * 250;
            double cenaCpu = (cenaVideoKarti * 0.35) * cpu;
            double cenaRam = (cenaVideoKarti * 0.10) * ram;
            double cena = cenaVideoKarti + cenaCpu + cenaRam;

            if (videoKarti > cpu) { cena *= 0.85; }
            if (budget >= cena) { Console.WriteLine($"You have {budget - cena:F2} leva left!"); }
            else { Console.WriteLine($"Not enough money! You need {cena - budget:F2} leva more!"); }
        }
    }
}