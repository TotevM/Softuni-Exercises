using System.Reflection.Metadata;

namespace Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(" ");
            Console.WriteLine(Sum(inputs[0], inputs[1]));
        }

        public static int Sum(string first, string second)
        {
            int sum = 0;

            int max=Math.Max(first.Length,second.Length);
            
            for (int i = 0; i < max; i++)
            {
                if (i < first.Length && i < second.Length)
                {
                    sum += first[i] * second[i];
                }
                else if (i < first.Length)
                {
                    sum += first[i];
                }
                else if (i < second.Length)
                {
                    sum += second[i];
                }
            }

            return sum;
        }
    }
}