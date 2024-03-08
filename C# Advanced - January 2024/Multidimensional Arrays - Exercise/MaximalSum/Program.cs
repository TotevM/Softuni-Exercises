namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int maxRow = 0;
            int maxCol = 0;
            int sum = 0;

            int[,] matrix = new int[rows, cols];
            int count = 0;
            for (int row = 0; row < rows; row++)
            {
                int[] rowArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowArr[col];
                }
            }
            for (int row = 0; row < rows-2; row++)
            {
                for (int col = 0; col < cols-2; col++)
                {
                    if (matrix[row,col]+ matrix[row, col+1]+ matrix[row, col+2]
                        + matrix[row+1, col] + matrix[row+1, col + 1] + matrix[row+1, col + 2]+
                        +matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2]>sum)
                    {
                        maxRow = row;
                        maxCol = col;
                        sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        +matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    }
                }
            }
            Console.WriteLine("Sum = "+sum);
            Console.WriteLine($"{matrix[maxRow,maxCol]} {matrix[maxRow, maxCol+1]} {matrix[maxRow, maxCol+2]}");
            Console.WriteLine($"{matrix[maxRow+1,maxCol]} {matrix[maxRow+1, maxCol+1]} {matrix[maxRow+1, maxCol+2]}");
            Console.WriteLine($"{matrix[maxRow+2,maxCol]} {matrix[maxRow+2, maxCol+1]} {matrix[maxRow+2, maxCol+2]}");
        }
    }
}
