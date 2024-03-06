using System;
using System.Linq;
using System.Collections.Generic;

namespace ListManipulationAdvanced
{
    class Program
    {
        static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (arr.Length == 1)
            {
                Console.WriteLine(0);
                return;
            }
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                leftSum = arr.Take(i).Sum(); //learn more about "take" and "skip"

                rightSum = arr.Skip(i + 1).Sum();

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("no");
        }
    }
}