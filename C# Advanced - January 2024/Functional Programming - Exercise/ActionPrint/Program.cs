using System.Threading.Channels;

namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split().ToArray();
            Action<string> newLinePrinter=text=>Console.WriteLine(text);

            foreach (var item in text)
            {
                newLinePrinter(item);
            }
        }
    }
}
