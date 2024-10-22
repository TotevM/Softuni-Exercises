using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> universe = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
        List<HashSet<int>> sets = new List<HashSet<int>>();

        int n=int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            HashSet<int> hs = Console.ReadLine().Split(", ").Select(int.Parse).ToHashSet();
            sets.Add(hs);
        }

        List<HashSet<int>> selectedSets = new List<HashSet<int>>();

        while (universe.Count > 0)
        {
            var bestSet = sets
                .OrderByDescending(s => s.Count(universe.Contains))
                .First();

            selectedSets.Add(bestSet);
            foreach (var element in bestSet)
            {
                universe.Remove(element);
            }

            sets.Remove(bestSet);
        }

        Console.WriteLine($"Sets to take ({selectedSets.Count}):");
        foreach (var set in selectedSets)
        {
            Console.WriteLine($"{string.Join(", ", set)}");
        }
    }
}
