using System.Diagnostics;
//wee_3, kakw(), askdskdoaskdoaskdosa, 12_34-23
namespace Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words) 
            {
                if (word.Length < 3 || word.Length > 16)
                {
                    continue;
                }
                
                bool toPrint = word.All(ch => char.IsLetterOrDigit(ch) || ch == '_' || ch =='-'); 

                if (toPrint)
                {
                    Console.WriteLine(word);
                }
                
            }
        }
    }
}