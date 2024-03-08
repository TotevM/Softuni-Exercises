namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> pumpsQueue = new Queue<int[]>();

            int currPosition = 0;
            for (int i = 0; i < n; i++)
            {
                int[] pumpInfo = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                pumpsQueue.Enqueue(pumpInfo);
            }

            while (true)
            {
                int currFuel = 0;
                foreach (int[] pump in pumpsQueue)
                {
                    int fuel = pump[0];
                    int distance = pump[1];
                    currFuel += fuel - distance;
                    if (currFuel < 0)
                    {
                        currPosition++;
                        pumpsQueue.Enqueue(pumpsQueue.Dequeue());
                        break;
                    }
                }
                if (currFuel >= 0)
                {
                    Console.WriteLine(currPosition);
                    break;
                }
            }
        }
    }
}
