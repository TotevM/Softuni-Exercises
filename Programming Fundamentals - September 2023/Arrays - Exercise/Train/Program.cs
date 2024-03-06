namespace train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] wagon = new int[n];
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                wagon[i] = int.Parse(Console.ReadLine());
                sum += wagon[i];
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{wagon[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine(sum);

        }
    }
}