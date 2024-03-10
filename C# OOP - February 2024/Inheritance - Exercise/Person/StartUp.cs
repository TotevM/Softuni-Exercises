using System;
namespace Person;

public class StartUp
{
    public static void Main(string[] args)
    {
        string childName = Console.ReadLine();
        uint childAge = uint.Parse(Console.ReadLine());
        uint ga = -1;
        Console.WriteLine(ga);

        Child child = new Child(childName, childAge);
        Console.WriteLine(child);
    }
}