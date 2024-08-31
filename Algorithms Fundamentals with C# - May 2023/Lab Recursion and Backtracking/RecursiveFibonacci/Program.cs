namespace RecursiveFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFibonacci(n));
        }

        private static int GetFibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }

            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}
