namespace QueensPuzzle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());

            int[,] board = new int[boardSize, boardSize];

            Console.WriteLine(GetQueens(board, 0));
        }
        static void Print(int[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == 1)
                    {
                        Console.Write("|Q|");
                    }
                    if (board[row, col] == 0)
                    {
                        Console.Write("|_|");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static int GetQueens(int[,] board, int row)
        {
            if (row == board.GetLength(0))
            {
                Print(board);
                return 1;
            }
            int foundQueens = 0;
            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (IsSafe(board, row, col))
                {
                    board[row, col] = 1;
                    foundQueens += GetQueens(board, row + 1);
                    board[row, col] = 0;
                }
            }
            return foundQueens;
        }

        private static bool IsSafe(int[,] board, int row, int col)
        {
            for (int i = 1; i < board.GetLength(0); i++)
            {
                if (row - i >= 0 && board[row - i, col] == 1)
                {
                    return false;
                }
                if (col - i >= 0 && board[row, col - i] == 1)
                {
                    return false;
                }
                if (row + i < board.GetLength(0) && board[row + i, col] == 1)
                {
                    return false;
                }
                if (col + i < board.GetLength(1) && board[row, col + i] == 1)
                {
                    return false;
                }
                if (col + i < board.GetLength(0) &&
                    row + i < board.GetLength(1) &&
                    board[row + i, col + i] == 1)
                {
                    return false;
                }
                if (col - i >= 0 &&
                    row + i < board.GetLength(1) &&
                    board[row + i, col - i] == 1)
                {
                    return false;
                }
                if (col - i >= 0 &&
                    row - i >= 0 &&
                    board[row - i, col - i] == 1)
                {
                    return false;
                }
                if (col + i < board.GetLength(0) &&
                    row - i >= 0 &&
                    board[row - i, col + i] == 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
