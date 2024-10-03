namespace NestedLoopsToRecursion
{
    public class Program
    {
        public static int[] arr;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            arr = new int[n];

            GenerateSolutions(0);
        }

        private static void GenerateSolutions(int ind)
        {
            if (ind == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[ind] = i + 1;
                GenerateSolutions(ind + 1);
            }
        }
    }
}