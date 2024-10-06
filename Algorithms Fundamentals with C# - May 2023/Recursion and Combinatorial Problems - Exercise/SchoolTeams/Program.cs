namespace SchoolTeams
{
    internal class Program
    {
        public const int girlsInTeam = 3;
        public const int boysInTeam = 2;

        static void Main(string[] args)
        {
            var girls = Console.ReadLine().Split(", ");
            var girlComb = new string[girlsInTeam];
            List<string[]> girlsCombos = new List<string[]>();

            GenCombs(0, 0, girls, girlComb, girlsCombos);

            var boys = Console.ReadLine().Split(", ");
            var boysComb = new string[boysInTeam];
            List<string[]> boysCombos = new List<string[]>();

            GenCombs(0, 0, boys, boysComb, boysCombos);

            foreach (var gc in girlsCombos)
            {
                foreach (var bc in boysCombos)
                {
                    Console.WriteLine($"{string.Join(", ", gc)} {string.Join(", ", bc)}");
                }
            }
        }

        private static void GenCombs(int ind, int start, string[] elements, string[] comb, List<string[]> combos)
        {
            if (ind >= comb.Length)
            {
                combos.Add(comb.ToArray());
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                comb[ind] = elements[i];
                GenCombs(ind + 1, i + 1, elements, comb, combos);
            }
        }
    }
}
