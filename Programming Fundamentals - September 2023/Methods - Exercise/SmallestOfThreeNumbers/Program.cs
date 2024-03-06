using System;

namespace Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());
            int firstmin = Math.Min(n1, n2);
            Console.WriteLine(Math.Min(firstmin, n3));
        }
    }
}
