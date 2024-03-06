using System.Linq;

namespace _05._Drum_Set
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> seq = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> initial = new List<int>();
            initial.AddRange(seq);
            string command;

            while ((command = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                for (int j = 0; j < seq.Count; j++)
                {
                    seq[j] -= int.Parse(command);
                    if (seq[j] <= 0)
                    {
                        if (savings >= initial[j] * 3)
                        {
                            savings -= initial[j] * 3;
                            seq[j] = initial[j];
                        }
                    }
                }
                for (int i = 0; i < seq.Count; i++)
                {
                    if (seq[i] <= 0)
                    {
                        seq.Remove(seq[i]);
                        initial.Remove(initial[i]);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", seq));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}