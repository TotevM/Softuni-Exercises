namespace BorderControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = new List<string>();
            string input;
            while ((input=Console.ReadLine())!="End")
            {
                string[] arguments=input.Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
                numbers.Add(arguments.Last());
            }
            string lastDigits = Console.ReadLine();

            foreach (string number in numbers.Where(x=>x.EndsWith(lastDigits))) 
            {
                    Console.WriteLine(number);
            }
        }
    }
}
