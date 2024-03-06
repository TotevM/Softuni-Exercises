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
            bool print = false;
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                List<string> activity = command.Split().ToList();
                switch (activity[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(activity[1]));
                        print = true;
                        break;

                    case "Remove":
                        numbers.Remove(int.Parse(activity[1]));
                        print = true;
                        break;

                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(activity[1]));
                        print = true;
                        break;

                    case "Insert":
                        print = true;
                        numbers.Insert(int.Parse(activity[2]), int.Parse(activity[1]));
                        break;

                    case "Contains":
                        if (numbers.Contains(int.Parse(activity[1])))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;

                    case "PrintEven":
                        List<int> evenNumbers= new List<int>();
                        for (int i=0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 == 0)
                            {
                                evenNumbers.Add(numbers[i]);
                            }
                        }
                        Console.WriteLine(string.Join(" ", evenNumbers));
                        break;

                    case "PrintOdd":
                        List<int> oddNumbers = new List<int>();
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 == 1)
                            {
                                oddNumbers.Add(numbers[i]);
                            }
                        }
                        Console.WriteLine(string.Join(" ", oddNumbers));
                        break;

                    case "GetSum":
                        int sum = 0;
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            sum += numbers[i];
                        }
                        Console.WriteLine(sum);
                        break;

                    case "Filter":
                        List<int> filtered= new List<int>();

                        if (activity[1] == "<")
                        {
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (numbers[i] < int.Parse(activity[2]))
                                {
                                    filtered.Add(numbers[i]);
                                }
                            }
                            Console.WriteLine(string.Join(" ", filtered));
                        }
                        if (activity[1] == ">")
                        {
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (numbers[i] > int.Parse(activity[2]))
                                {
                                    filtered.Add(numbers[i]);
                                }
                            }
                            Console.WriteLine(string.Join(" ", filtered));
                        }
                        if (activity[1] == "<=")
                        {
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (numbers[i] <= int.Parse(activity[2]))
                                {
                                    filtered.Add(numbers[i]);
                                }
                            }
                            Console.WriteLine(string.Join(" ", filtered));
                        }
                        if (activity[1] == ">=")
                        {
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (numbers[i] >= int.Parse(activity[2]))
                                {
                                    filtered.Add(numbers[i]);
                                }
                            }
                            Console.WriteLine(string.Join(" ", filtered));
                        }
                        break;
                }
            }
            if (print)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}