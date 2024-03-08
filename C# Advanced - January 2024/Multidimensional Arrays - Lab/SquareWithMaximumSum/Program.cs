namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixInput[0];
            int cols = matrixInput[1];
            int maxRow=1, maxCol=1;
            int maxSum = int.MinValue;

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowArray = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowArray[col];
                }
            }
            for (int i = 0; i < rows-1; i++)
            {
                for (int k = 0; k < cols-1; k++)
                {
                    if (matrix[i,k]+ matrix[i, k+1]+ matrix[i+1, k]+ matrix[i+1, k+1]>maxSum)
                    {
                        maxSum = matrix[i, k] + matrix[i, k + 1] + matrix[i + 1, k] + matrix[i + 1, k + 1];
                        maxRow=i; maxCol = k;
                    }
                }
            }
            Console.WriteLine($"{matrix[maxRow,maxCol]} {matrix[maxRow, maxCol + 1]} ");
            Console.WriteLine($"{matrix[maxRow+1,maxCol]} {matrix[maxRow+1, maxCol + 1]} ");
            Console.WriteLine(maxSum);
        }
    }
}
