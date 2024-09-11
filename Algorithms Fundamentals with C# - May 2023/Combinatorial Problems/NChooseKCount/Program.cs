namespace NChooseKCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetCombinationsCount(k, n));
        }

        private static int GetCombinationsCount(int n, int k)
        {
            return GetFactorial(n) / (GetFactorial(k) * GetFactorial(n - k));
        }

        private static int GetFactorial(int number)
        {
            if (number==1 || number==0)
            {
                return 1;
            }

            return number * GetFactorial(number - 1);
        }
    }
}
