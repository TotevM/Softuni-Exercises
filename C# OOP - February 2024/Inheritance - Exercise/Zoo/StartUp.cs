using System;

namespace Zoo;

public class StartUp
{
    public static void Main(string[] args)
    {
        string gorillaName = Console.ReadLine();
        Animal gorilla = new Gorilla(gorillaName);

        string snakeName = Console.ReadLine();
        Animal snake = new Snake(snakeName);

        string lizzardName = Console.ReadLine();
        Animal lizzard = new Lizard(lizzardName);

        string bearName = Console.ReadLine();
        Animal bear = new Bear(bearName);

        Console.WriteLine($"Gorilla's name: {gorilla.Name}");
        Console.WriteLine($"Snake's name: {snake.Name}");
        Console.WriteLine($"Lizzard's name: {lizzard.Name}");
        Console.WriteLine($"Bear's name: {bear.Name}");
    }
}