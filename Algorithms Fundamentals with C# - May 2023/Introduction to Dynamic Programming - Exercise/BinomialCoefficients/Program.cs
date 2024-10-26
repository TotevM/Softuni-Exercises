namespace BinomialCoefficients
{
    public class Program
    {
        private static Dictionary<string, int> cache;
        static void Main(string[] args)
        {
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());

            cache=new Dictionary<string, int>();

            Console.WriteLine(GetBinom(row,col));
        }

        private static int GetBinom(int row, int col)
        {
            if (col==0 || col==row)
            {
                return 1;
            }

            var key = $"{row}-{col}";

            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            var result = GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);
            cache[key] = result;

            return result;
        }
    }
}
