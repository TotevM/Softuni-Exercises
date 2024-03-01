using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_of_odd_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i * 2 - 1);
                sum += i * 2 - 1;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}