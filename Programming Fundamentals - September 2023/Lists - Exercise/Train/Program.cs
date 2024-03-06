using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int capacity=int.Parse(Console.ReadLine());
            string input;
            
            while ((input = Console.ReadLine()) != "end")
                
            {
                List<string> activity=input.Split().ToList();
                if (activity[0] == "Add")
                {
                    wagons.Add(int.Parse(activity[1]));
                }
                
                else
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + int.Parse(activity[0]) <= capacity)
                        {
                            wagons[i] += int.Parse(activity[0]);
                            break;
                        }
                    }
                }

            }
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}