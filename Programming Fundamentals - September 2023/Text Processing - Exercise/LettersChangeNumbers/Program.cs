using System.Diagnostics.Tracing;

namespace Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double finalSum = 0;
       
            foreach (string word in input)
            {
                double number = double.Parse(word.Substring(1, word.Length - 2));

                if (char.IsLower(word[0]))
                {
                    int letterPositionInAlphabet = word[0] - 'a'+1;
                    number = number * letterPositionInAlphabet;
                }
                else if (char.IsUpper(word[0]))
                {
                    int letterPositionInAlphabet = word[0] - 'A'+1;
                    number = number / letterPositionInAlphabet;
                }

                if (char.IsLower(word[word.Length - 1]))
                {
                    int letterPositionInAlphabet = word[word.Length - 1] - 'a'+1;
                    number = number + letterPositionInAlphabet;
                }
                else if (char.IsUpper(word[word.Length - 1]))
                {
                    int letterPositionInAlphabet = word[word.Length - 1] - 'A' + 1;
                    number = number - letterPositionInAlphabet;
                }
                finalSum += number;
            }
            Console.WriteLine($"{finalSum:f2}");
        }
    }
}