namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            
            List<int> numbers = new List<int>();
            for (int i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> filter=num=>true;

            if (command == "even")
            {
                filter = num => num % 2 == 0;
            }
            if (command == "odd")
            {
                filter = num => num % 2 != 0;
            }
            Console.WriteLine(string.Join(" ", numbers.FindAll(filter)));
        }
    }
}
