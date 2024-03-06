namespace _04._Mixed_up_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToList();

            List<int> secondList = Console.ReadLine()
                             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToList();

            int len = Math.Min(firstList.Count, secondList.Count);

            List<int> mixed = new List<int>(len);

            secondList.Reverse();

            for (int i = 0; i < len; i++)
            {
                mixed.Add(firstList[i]);
                mixed.Add(secondList[i]);
            }

            int start = 0;
            int end = 0;

            if (firstList.Count > secondList.Count)
            {
                start = firstList[firstList.Count - 1];
                end = firstList[firstList.Count - 2];
            }
            else
            {
                start = secondList[secondList.Count - 1];
                end = secondList[secondList.Count - 2];
            }

            List<int> output = new List<int>();

            output = mixed.Where(n => n > Math.Min(end, start) && n < Math.Max(end, start)).ToList();
            output.Sort();
            Console.WriteLine(string.Join(" ", output));
        }
    }
}