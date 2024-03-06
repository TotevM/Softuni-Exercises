using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            GetTopNumber(n);
        }
        static void GetTopNumber(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                int curr = i;
                int sum = 0;
                bool isOdd = false;
                while (curr != 0)
                {
                    sum += curr % 10;
                    if ((curr % 10) % 2 == 1)
                        isOdd = true;
                    curr /= 10;
                }
                if (sum % 8 == 0 && isOdd)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}