using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;

namespace Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToList();
            List<int> bombAndPower = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (bombAndPower[0] == numbers[i])
                {
                    for (int k = 1; k <= bombAndPower[1]; k++)
                    {
                        if (i - k < 0)
                        {
                            break;
                        }
                        else
                        {
                            numbers[i - k] = 0;
                        }
                    }
                    for (int k = 1; k <= bombAndPower[1]; k++)
                    {
                        if (i + k > numbers.Count-1)
                        {
                            break;
                        }
                        else
                        {
                            numbers[i + k] = 0;
                        }
                    }
                    numbers[i] = 0;
                }
            }
            int sum=numbers.Sum();
            Console.WriteLine(sum);
        }
    }
}