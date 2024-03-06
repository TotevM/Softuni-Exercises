using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
namespace Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int ctr = 0;
            char[] vowels = { 'A', 'a', 'E', 'e', 'O', 'o', 'i', 'I', 'U', 'u' };
            foreach (char c in word)
            {
                if (vowels.Contains(c))
                {
                    ctr++;
                }
            }
            Console.WriteLine(ctr);
        }
    }
}