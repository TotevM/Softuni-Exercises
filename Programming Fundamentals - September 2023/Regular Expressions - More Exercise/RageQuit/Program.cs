using System.Text;
using System.Text.RegularExpressions;

namespace _02._Rage_Quit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<string>[^\d]+)(?<count>[\d]+)";

            StringBuilder output = new StringBuilder();
            foreach (Match match in Regex.Matches(input, pattern))
            {
                string str = match.Groups["string"].Value;
                int repeatCount = int.Parse(match.Groups["count"].Value);

                for (int i = 0; i < repeatCount; i++)
                {
                    output.Append(str.ToUpper());
                }
            }

            int uniqueSymbols = output.ToString().Distinct().Count(); //polzvame distinct za da broim i sluchaite v koito simvola ne se povtarq
            Console.WriteLine($"Unique symbols used: {uniqueSymbols}");
            Console.WriteLine(output.ToString());
        }
    }
}