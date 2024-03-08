namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows=n; int cols=n;
            int[,] arr=new int[rows, cols];
            int firstDiagonalSum = 0;
            int secondDiagonalSum = 0;

            for (int i = 0; i < rows; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int k = 0; k<cols; k++)
                {
                    arr[i,k] = input[k];
                }
            }
            for (int i = 0; i < n; i++)
            {
                firstDiagonalSum += arr[i, i];
            }
            for (int i = 0; i < rows; i++)
            {
                secondDiagonalSum += arr[i, cols - i - 1];
            }
            Console.WriteLine(Math.Abs(firstDiagonalSum-secondDiagonalSum));
        }
    }
}
