using System.Collections.Generic;

namespace Gauss__Trick
{
    internal class Program
    {
        static void Main()
        {
            List<double> numbers = Console.ReadLine()
                                   .Split()
                                   .Select(double.Parse)
                                   .ToList();

            List<double> final = new List<double>();

                for (int i = 0; i < numbers.Count / 2; i++)
                {
                    final.Add(numbers[i] + numbers[numbers.Count - i - 1]);
                }
            if (numbers.Count % 2 == 1)
            {
                final.Add(numbers[(numbers.Count / 2)]);
            }
            Console.WriteLine(string.Join(" ", final));
        }
    }
}