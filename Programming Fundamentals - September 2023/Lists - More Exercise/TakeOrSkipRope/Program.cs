using System.Text.RegularExpressions;

namespace _03._Take_or_Skip_Rope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rope = Console.ReadLine();
            List<int> numbers = new List<int>();
            List<string> nonNumbers = new List<string>();

            foreach (char c in rope)
            {
                if (char.IsDigit(c))
                {
                    numbers.Add(int.Parse(c.ToString()));
                }
                else
                    nonNumbers.Add(c.ToString());
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }

            string result = "";
            int takeCount = 0;
            int skipCount = 0;
            int start = 0;
            int end = 0;
            for (int i = 0; i < takeList.Count; i++)
            {
                takeCount = takeList[i];
                start = skipCount;
                end = start + takeCount;
                if (end > nonNumbers.Count)
                {
                    end = nonNumbers.Count;
                }
                for (int j = start; j < end; j++)
                {
                    result += nonNumbers[j];
                }
                skipCount += skipList[i] + takeCount;

            }
            Console.WriteLine(result);
        }
    }
}