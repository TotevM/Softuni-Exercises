namespace Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<string, List<string>> courseAndMembers = new Dictionary<string, List<string>>();

            string input;
            while ((input=Console.ReadLine()) != "end")
            {
                string[] argument = input.Split(" : ");               

                if (!courseAndMembers.ContainsKey(argument[0]))
                {
                    courseAndMembers.Add(argument[0], new List<string>());
                    courseAndMembers[argument[0]].Add(argument[1]);
                }
                else
                {
                    courseAndMembers[argument[0]].Add(argument[1]);
                }
            }

            foreach (var pair in courseAndMembers)
            {
                    Console.WriteLine($"{pair.Key}: {pair.Value.Count}");
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    Console.WriteLine($"-- {pair.Value[i]}");
                }
            }
        }
    }
}