namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int divisor = int.Parse(Console.ReadLine());

            Predicate<int> filter = n => n % divisor != 0;
            nums = nums.FindAll(filter);
                nums.Reverse();

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
