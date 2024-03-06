using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToList();
            string command;
            
            while ((command = Console.ReadLine()) != "End")
            {
                List<string> activity = command.Split().ToList();
                switch (activity[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(activity[1]));
                        break;

                    case "Insert":
                        if (int.Parse(activity[2]) < 0 || int.Parse(activity[2]) >= numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            numbers.Insert(int.Parse(activity[2]), int.Parse(activity[1]));
                        }
                        break;
                        

                    case "Remove":
                        if (int.Parse(activity[1]) < 0 || int.Parse(activity[1]) >= numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            numbers.RemoveAt(int.Parse(activity[1]));
                        }
                            break;

                    case "Shift":
                        if (activity[1] == "left")
                        {
                            for (int i = 0; i < int.Parse(activity[2]); i++)
                            {
                                numbers.Add(numbers[0]);
                                numbers.RemoveAt(0);
                            }
                        }
                        else if (activity[1] == "right")
                        {
                            for (int i = 0; i < int.Parse(activity[2]); i++)
                            {
                                numbers.Insert(0, numbers[numbers.Count-1]);
                                numbers.RemoveAt(numbers.Count - 1);
                            }
                        }
                        break;
                }
            }
                Console.WriteLine(string.Join(" ", numbers));
        }
    }
}