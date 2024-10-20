using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] coins = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int targetSum = int.Parse(Console.ReadLine());

        coins.OrderByDescending(x=>x);

        Dictionary<int, int> usedCoins = new Dictionary<int, int>();
        int totalCoins = 0;
        int currentSum = 0;

        foreach (var coin in coins)
        {
            int count = (targetSum - currentSum) / coin;
            if (count > 0)
            {
                usedCoins[coin] = count;
                totalCoins += count;
                currentSum += count * coin;
            }

            if (currentSum == targetSum)
                break;
        }

        if (currentSum == targetSum)
        {
            Console.WriteLine($"Number of coins to take: {totalCoins}");
            foreach (var coin in usedCoins)
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }
        else
        {
            Console.WriteLine("Error");
        }
    }
}
