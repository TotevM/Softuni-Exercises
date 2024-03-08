namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            for (int i = 0; i < commands[1]; i++)
            {
                numbers.Pop();
            }
            if (numbers.Contains(commands[2]))
            {
                Console.WriteLine("true");
            }
            else if(numbers.Count==0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(numbers.Min());
            }
        }
    }
}