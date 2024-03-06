using System;
class Program
{
    static void Main()
    {

        int firstRange = int.Parse(Console.ReadLine());
        int secondRange = int.Parse(Console.ReadLine());

        for (int i = firstRange; i <= secondRange; i++)
        {
            Console.Write((char)i + " ");
        }
    }
}