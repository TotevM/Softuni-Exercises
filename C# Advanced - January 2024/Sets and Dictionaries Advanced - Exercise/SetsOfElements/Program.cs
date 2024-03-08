namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] setsLenghts = Console.ReadLine().Split().Select(int.Parse).ToArray();

            HashSet<int> firstSet = new HashSet<int>(setsLenghts[0]);
            HashSet<int> secondSet = new HashSet<int>(setsLenghts[1]);
            HashSet<int> outputSet = new HashSet<int>();

            for (int i = 0; i < setsLenghts[0]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                firstSet.Add(num);
            }
            for (int i = 0; i < setsLenghts[1]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                secondSet.Add(num);
            }
            foreach (var number1 in firstSet)
            {
                foreach (var number2 in secondSet)
                {
                    if (number1==number2)
                    {
                        outputSet.Add(number1);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", outputSet));
        }
    }
}
