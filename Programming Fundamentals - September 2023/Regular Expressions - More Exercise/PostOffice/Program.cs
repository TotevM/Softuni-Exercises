using System.Text.RegularExpressions;

namespace _03._Post_Office
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("|");

            string firstPart = input[0];
            string secondPart = input[1];
            string thirdPart = input[2];

            string firstPattern = @"([#$%*&])(?<capitals>[A-Z]+)(\1)";
            Match firstMatch = Regex.Match(firstPart, firstPattern);
            string capitals = firstMatch.Groups["capitals"].Value;

            for (int i = 0; i < capitals.Length; i++)
            {
                char startLetter = capitals[i];
                int ASCIIcode = startLetter;

                string secondPattern = $@"{ASCIIcode}:(?<length>[0-9][0-9])";
                Match secondMatch = Regex.Match(secondPart, secondPattern);
                int length = int.Parse(secondMatch.Groups["length"].Value);

                string thirdPattern = $@"(?<=\s|^){startLetter}[^\s]{{{length}}}(?=\s|$)"; // optimised regex to do most of the work
                Match thirdMatch = Regex.Match(thirdPart, thirdPattern); // otkradnah golqma chast ot koda
                string word = thirdMatch.ToString();

                Console.WriteLine(word);
            }
        }
    }
}