namespace Godzilla_vs._Kong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statisti = int.Parse(Console.ReadLine());
            double cena = double.Parse(Console.ReadLine());

            double dekor = budget * 0.1;
            if (statisti > 150) { cena = cena * 0.9; }
            double obshto = dekor + (cena * statisti);
            if (obshto > budget) { Console.WriteLine("Not enough money!"); Console.WriteLine($"Wingard needs {(obshto - budget):F2} leva more."); }
            else if (obshto <= budget) { Console.WriteLine("Action!"); Console.WriteLine($"Wingard starts filming with {(budget - obshto):F2} leva left."); }
        }
    }
}