using System.Collections.Generic;

namespace Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
              List<double> numbers1 = Console.ReadLine()
                      .Split()
                      .Select(double.Parse)
                      .ToList();
              List<double> numbers2 = Console.ReadLine()
                        .Split()
                        .Select(double.Parse)
                        .ToList();
            List<double> result= new List<double>();
            int itterations=Math.Max(numbers1.Count, numbers2.Count);

            for (int i = 0; i < itterations; i++)
            {
                if (numbers1.Count>i)
                {
                    result.Add(numbers1[i]);
                }
                if (numbers2.Count > i)
                {
                result.Add(numbers2[i]);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}