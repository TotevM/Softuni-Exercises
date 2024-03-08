namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> streamers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string command;
            while ((command=Console.ReadLine())!= "Statistics")
            {
                string[] input = command.Split();

                if (input[1]== "joined" && !streamers.ContainsKey(input[0]))
                {
                    streamers[input[0]] = new Dictionary<string, HashSet<string>>();
                    streamers[input[0]].Add("following", new HashSet<string>());
                    streamers[input[0]].Add("followers", new HashSet<string>());
                }
                else if (input[1] == "followed")
                {
                    if (input[0] != input[2]
                        && streamers.ContainsKey(input[0])
                        && streamers.ContainsKey(input[2]))
                    {
                        streamers[input[0]]["following"].Add(input[2]);
                        streamers[input[2]]["followers"].Add(input[0]);
                    }
                }
            }
            
            Console.WriteLine($"The V-Logger has a total of {streamers.Count} vloggers in its logs.");

            int number = 1;

            foreach (var vlogger in streamers.OrderByDescending(v => v.Value["followers"].Count).ThenBy(v => v.Value["following"].Count))
            {
                Console.WriteLine($"{number}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
                if (number == 1)
                {
                    foreach (string follower in vlogger.Value["followers"].OrderBy(f => f))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                number++;
            }
        }
    }
}
