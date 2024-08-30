namespace GeneratingZeroAndOneVectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] output = new int[n];

            GenerateOutputRecursively(0, output);
        }

        private static void GenerateOutputRecursively(int i, int[] output)
        {
            if (i==output.Count())
            {
                Console.WriteLine(string.Join("", output));
                return;
            }
            for (int j = 0; j < 2; j++)
            {
                output[i] = j;
                GenerateOutputRecursively(i + 1, output);
            }
        }
    }
}
