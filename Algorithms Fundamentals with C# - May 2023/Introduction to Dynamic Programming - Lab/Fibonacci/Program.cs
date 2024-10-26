namespace Fibonacci
{
    public class Program
    {
        public static Dictionary<int, long> cache;
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            cache = new Dictionary<int, long>();
            Console.WriteLine(Fibonacci(n));
        }

        private static long Fibonacci(int n)
        {

            if (n < 2)
            {
                return n;
            }
            if (!cache.ContainsKey(n))
            {
                cache[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
            }

            return cache[n];
        }
    }
}
