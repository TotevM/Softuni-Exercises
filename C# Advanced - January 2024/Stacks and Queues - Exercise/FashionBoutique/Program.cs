namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(inputInfo);

            int rackCapacity = int.Parse(Console.ReadLine());
            int currRackCapacity = rackCapacity;
            int racksCount = 1;

            while (stack.Count > 0)
            {
                if (stack.Peek() <= currRackCapacity)
                {
                    currRackCapacity -= stack.Pop();
                }
                else
                {
                    racksCount++;
                    currRackCapacity = rackCapacity;
                }
            }

            Console.WriteLine(racksCount);
        }
    }
}
