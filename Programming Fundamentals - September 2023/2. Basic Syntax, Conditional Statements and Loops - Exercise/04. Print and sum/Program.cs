using System;

public class Program
{
    public static void Main()
    {
        int sum = 0;
        int first = Convert.ToInt32(Console.ReadLine());
        int second = Convert.ToInt32(Console.ReadLine());
        for (int i = first; i <= second; i++)
        {
            sum += i;
            Console.Write($"{i} ");
        }
        Console.WriteLine();
        Console.WriteLine($"Sum: {sum}");
    }
}