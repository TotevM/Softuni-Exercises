using System.Collections.Generic;

namespace List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                        .Split()
                        .Select(double.Parse)
                        .ToList();
            string command;
            while ((command=Console.ReadLine())!="end")
            {
                List<string> activity = command.Split().ToList();
                switch (activity[0]) 
                {
                    case "Add":
                        numbers.Add(double.Parse(activity[1]));
                        break;

                    case "Remove":
                        numbers.Remove(double.Parse(activity[1]));
                        break;

                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(activity[1]));
                        break;

                    case "Insert":
                        numbers.Insert(int.Parse(activity[2]), int.Parse(activity[1]));
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}