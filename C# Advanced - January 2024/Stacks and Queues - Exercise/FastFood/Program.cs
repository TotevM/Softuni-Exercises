namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int orders=int.Parse(Console.ReadLine());
            Queue<int> numbers = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            
            Console.WriteLine(numbers.Max());

            while (true)
            {
                if (numbers.Count == 0)
                {
                    Console.WriteLine("Orders complete");
                    break;
                } 

                if (orders >= numbers.Peek())
                {
                    orders -= numbers.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", numbers)}");
                    
                    break;
                }

            }
        }
    }
}
