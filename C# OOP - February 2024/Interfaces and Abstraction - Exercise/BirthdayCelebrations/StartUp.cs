using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations;

public class StartUp
{
    static void Main(string[] args)
    {
        List<IBuyer> livingEntities = new();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] entityTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (entityTokens.Length == 3)
            {
                Rebel entity = new(entityTokens[0], int.Parse(entityTokens[1]), entityTokens[2]);
                livingEntities.Add(entity);
            }
            else
            {
                Citizen entity = new(entityTokens[0], int.Parse(entityTokens[1]), entityTokens[2], entityTokens[3]);
                livingEntities.Add(entity);
            }
        }

        int sum = 0;
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            if (livingEntities.Any(x => x.Name == input))
            {
                IBuyer buyer = livingEntities.First(x => x.Name == input);

                buyer.BuyFood();
                sum += buyer.BuyFood();
            }
        }
        Console.WriteLine(sum);
    }
}