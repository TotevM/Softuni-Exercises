namespace _02._Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            double sumLeft = 0, sumRight = 0;
            for (int i = 0; i < input.Count / 2; i++)
            {
                sumLeft += input[i];
                if (input[i] == 0)
                {
                    sumLeft *= 0.8;
                }
            }
            for (int i = input.Count - 1; i > input.Count / 2; i--)
            {
                sumRight += input[i];
                if (input[i] == 0)
                {
                    sumRight *= 0.8;
                }
            }
            if (sumLeft < sumRight)
            {
                Console.WriteLine($"The winner is left with total time: {sumLeft}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {sumRight}");
            }
        }
    }
}