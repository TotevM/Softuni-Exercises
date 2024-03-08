using System;

namespace KnightGame
{
    class Program
    {
        static void Main()
        {
            int boardSide = int.Parse(Console.ReadLine());

            string[,] board = new string[boardSide, boardSide];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = currentRow[col].ToString();
                }
            }

            int knightsInDangerCounter = 0; 
            int removedKnightsCounter = 0; 

            for (int maxAttackPotential = 8; maxAttackPotential > 0; maxAttackPotential--) 
            { 
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (board[row, col].ToLower() == "k") 
                        {
                            if (row - 1 >= 0)
                            {
                                if (col - 2 >= 0)
                                {
                                    if (board[row - 1, col - 2].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }

                                if (col + 2 < board.GetLength(1))
                                {
                                    if (board[row - 1, col + 2].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }
                            }

                            if (row + 1 < board.GetLength(0))
                            {
                                if (col - 2 >= 0)
                                {
                                    if (board[row + 1, col - 2].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }

                                if (col + 2 < board.GetLength(1))
                                {
                                    if (board[row + 1, col + 2].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }
                            }

                            if (row - 2 >= 0)
                            {
                                if (col - 1 >= 0)
                                {
                                    if (board[row - 2, col - 1].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }

                                if (col + 1 < board.GetLength(1))
                                {
                                    if (board[row - 2, col + 1].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }
                            }

                            if (row + 2 < board.GetLength(0))
                            {
                                if (col - 1 >= 0)
                                {
                                    if (board[row + 2, col - 1].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }

                                if (col + 1 < board.GetLength(1))
                                {
                                    if (board[row + 2, col + 1].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }
                            }
                        }

                        if (knightsInDangerCounter == maxAttackPotential)
                        {
                            board[row, col] = "0";
                            removedKnightsCounter++;
                        }

                        knightsInDangerCounter = 0;
                    }
                }
            }
            Console.WriteLine(removedKnightsCounter);
        }
    }
}