using System;

public class Program
{
    public static void Main()
    {
        int people = Convert.ToInt32(Console.ReadLine());
        int capacity = Convert.ToInt32(Console.ReadLine());

        int courses = (int)Math.Ceiling((double)people / capacity);
        Console.WriteLine(courses);
    }
}