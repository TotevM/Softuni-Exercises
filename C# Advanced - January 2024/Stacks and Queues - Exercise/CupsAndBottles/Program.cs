namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> excessWater = new Stack<int>();
            int value = 0;

            while (cups.Count!=0 && bottles.Count!=0)
            {
                if (bottles.Peek() > cups.Peek())
                {
                    excessWater.Push(bottles.Pop() - cups.Dequeue());
                }
                else if (bottles.Peek() == cups.Peek())
                {
                    bottles.Pop();
                    cups.Dequeue();
                }
                else if (bottles.Peek() < cups.Peek())
                {
                    while (cups.Peek() > value)
                    {
                            value += bottles.Pop();
                    }
                    excessWater.Push(value - cups.Dequeue());
                    value = 0;
                }  
            }
            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                Console.WriteLine($"Wasted litters of water: {excessWater.Sum()}");
            }
            else if (bottles.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                Console.WriteLine($"Wasted litters of water: {excessWater.Sum()}");
            }
        }
    }
}
