namespace MoveDownAndRight
{
    public class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, cols];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                var elements = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int c = 0; c < elements.Length; c++)
                {
                    matrix[r, c] = elements[c];
                }
            }

            var dp = new int[rows, cols];
            dp[0, 0] = matrix[0, 0];

            for (int c = 1; c < cols; c++)
            {
                dp[0, c] = dp[0, c - 1] + matrix[0, c];
            }

            for (int r = 1; r < rows; r++)
            {
                dp[r, 0] = dp[r - 1, 0] + matrix[r, 0];
            }

            for (int r = 1; r < rows; r++)
            {
                for (int c = 1; c < cols; c++)
                {
                    var upper = dp[r - 1, c];
                    var left = dp[r, c-1];

                    dp[r, c] = Math.Max(upper, left) + matrix[r, c];
                }
            }

            var row = rows - 1;
            var col = cols - 1;
            var path = new Stack<string>();
            while (row>0 && col>0)
            {
                path.Push($"[{row}, {col}]");
                var upper = dp[row - 1, col];
                var left = dp[row, col - 1];

                if (upper>left)
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            while (row > 0)
            {
                path.Push($"[{row}, {col}]");
                row--;
            }
            while(col>0)
            {
                path.Push($"[{row}, {col}]");
                col--;
            }

            Console.WriteLine(string.Join(" ", path));
        }
    }
}
