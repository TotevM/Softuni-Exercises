namespace Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courseAndMembers = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] argument = input.Split(" -> ");

                if (!courseAndMembers.ContainsKey(argument[0]))
                {
                    courseAndMembers.Add(argument[0], new List<string>());
                    courseAndMembers[argument[0]].Add(argument[1]);
                }
                else if (courseAndMembers.ContainsKey(argument[0]) && courseAndMembers[argument[0]].Contains(argument[1]))
                {
                    continue;
                }
                else
                {
                courseAndMembers[argument[0]].Add(argument[1]);
                } 
            }

            foreach (var pair in courseAndMembers)
            {
                Console.WriteLine($"{pair.Key}");
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    Console.WriteLine($"-- {pair.Value[i]}");
                }
            }
        }
    }
}