using System.Collections.Generic;

namespace Remove_Negatives_and_Reverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
    .Split()
    .Select(double.Parse)
    .ToList();
            List<double> result= new List<double>();


            numbers.RemoveAll(numbers => numbers < 0);

            if (numbers.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    result.Add(numbers[i]);
                }
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}