namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split().ToArray();

            Action<string> newLinePrinter = text => Console.WriteLine("Sir "+ text);

            foreach (var item in text)
            {
                newLinePrinter(item);
            }
        }
    }
}
