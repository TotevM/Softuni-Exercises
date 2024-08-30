namespace RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(SumArrRecursively(arr, 0));
        }

        private static int SumArrRecursively(int[] arr, int index)
        {
            if (index==arr.Length-1)
            {
                return arr[index];
            }

            return arr[index] + SumArrRecursively(arr, index + 1);
        }
    }
}
