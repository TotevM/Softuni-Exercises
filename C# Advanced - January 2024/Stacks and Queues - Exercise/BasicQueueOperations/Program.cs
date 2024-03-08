namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> numbers = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            for (int i = 0; i < commands[1]; i++)
            {
                numbers.Dequeue();
            }
            if (numbers.Contains(commands[2]))
            {
                Console.WriteLine("true");
            }
            else if (numbers.Count == 0)
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
