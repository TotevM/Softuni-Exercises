using System.Runtime.InteropServices;

namespace _06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();
            List<int> secondhand = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

            while (true)
            {
                if (firstHand[0] > secondhand[0])
                {
                    firstHand.Add(firstHand[0]);
                    firstHand.Add(secondhand[0]);
                }
                else if (firstHand[0] < secondhand[0])
                {
                    secondhand.Add(secondhand[0]);
                    secondhand.Add(firstHand[0]);
                }

                firstHand.Remove(firstHand[0]);
                secondhand.Remove(secondhand[0]);

                if (firstHand.Count == 0)
                {
                    int sum = secondhand.Sum();
                    Console.WriteLine($"Second player wins! Sum: {sum}");
                    break;
                }
                else if (secondhand.Count == 0)
                {
                    int sum = firstHand.Sum();
                    Console.WriteLine($"First player wins! Sum: {sum}");
                    break;
                }
            }
        }
    }
}