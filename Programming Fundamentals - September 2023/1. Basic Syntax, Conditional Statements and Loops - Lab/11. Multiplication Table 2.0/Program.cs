using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication_table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            if (m > 10)
            {
                Console.WriteLine($"{n} X {m} = {n * m}");
            }
            for (int i = n; i <= n; i++)
            {
                for (int j = m; j <= 10; j++)
                {
                    Console.WriteLine($"{i} X {j} = {i * j}");
                }
            }
        }
    }
}