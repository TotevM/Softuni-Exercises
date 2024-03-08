namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int[], bool> isDividable = (num, arr) =>
            {
                foreach (var item in arr)
                {
                    if (num % item != 0)
                    {
                        return false;
                    }
                }
                return true;
            };
            for (int i = 1; i <= n; i++)
            {
                if (isDividable(i, dividers))
                {
                    Console.Write(i+" ");
                }
            }
        }
    }
}