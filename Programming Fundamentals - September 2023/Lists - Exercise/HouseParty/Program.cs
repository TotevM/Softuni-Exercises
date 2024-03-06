namespace House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> finalList= new List<string>();

            for (int i = 0; i < n; i++) 
            {
            List<string> command=Console.ReadLine()
                    .Split()
                    .ToList();

                if (command[2] == "going!")
                {
                    if (finalList.Contains(command[0]))
                    {
                        Console.WriteLine($"{command[0]} is already in the list!");
                    }
                    else
                    {
                        finalList.Add(command[0]);
                    }
                }
                if (command[2] == "not")
                {
                    if (finalList.Contains(command[0]))
                    {
                        finalList.Remove(command[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{command[0]} is not in the list!");
                    }
                }
            }
            for (int i = 0; i < finalList.Count; i++)
            {
                Console.WriteLine(finalList[i]);
            }
        }
    }
}