using System;
namespace RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(FactorialRecursively(n));
        }

        private static int FactorialRecursively(int i)
        {
            if (i==0)
            {
                return 1;
            }
            return i * FactorialRecursively(i - 1);
        }
    }
}
