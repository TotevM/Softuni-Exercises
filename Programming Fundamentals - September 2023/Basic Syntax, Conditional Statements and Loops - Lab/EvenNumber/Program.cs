using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Even_number
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int num = int.Parse(Console.ReadLine());
                if (Math.Abs(num) % 2 != 0)
                {
                    Console.WriteLine($"Please write an even number.");
                }
                else
                {
                    Console.WriteLine($"The number is: {Math.Abs(num)}");
                    return;
                }
            }
        }
    }
}
namespace Even_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}