using System.Collections.Generic;

namespace Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToList();
            string input;

            while ((input=Console.ReadLine())!="end") 
            {
            List<string> activity=input.Split().ToList();
                if (activity[0] == "Delete")
                {
                    numbers.Remove(int.Parse(activity[1]));
                }
                if (activity[0] == "Insert")
                {
                    numbers.Insert(int.Parse(activity[2]), int.Parse(activity[1]));
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}