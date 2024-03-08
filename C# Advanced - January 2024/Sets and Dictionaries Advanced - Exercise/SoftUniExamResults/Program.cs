using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            var userPoints = new Dictionary<string, int>();
            var submissions = new Dictionary<string, int>();
            var userData =
                  new Dictionary<string, Dictionary<string, double>>();

            var input = Console.ReadLine();
            while (input != "exam finished")
            {
                var inputArgs = input.Split("-");

                var user = inputArgs[0];
                var languageOrBan = inputArgs[1];
                if (languageOrBan == "banned")
                {
                    userPoints.Remove(user);
                    input = Console.ReadLine();
                    continue;
                }
                var points = int.Parse(inputArgs[2]);
                if (!userPoints.ContainsKey(user))
                {
                    userPoints[user] = 0;
                }
                userPoints[user] = Math.Max(userPoints[user], points);
                if (!submissions.ContainsKey(languageOrBan))
                {
                    submissions[languageOrBan] = 0;
                }
                submissions[languageOrBan] += 1;
                input = Console.ReadLine();
            }
            Console.WriteLine("Results:");
            foreach (var kvp in userPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine(kvp.Key + " | " + kvp.Value);
            }
            Console.WriteLine("Submissions:");
            foreach (var kvp in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine(kvp.Key + " - " + kvp.Value);
            }
        }
    }
}