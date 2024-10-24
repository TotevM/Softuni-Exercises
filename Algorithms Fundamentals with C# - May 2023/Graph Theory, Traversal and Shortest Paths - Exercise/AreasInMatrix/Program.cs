using System;
using System.Collections.Generic;

public class Problem
{
    static char[,] matrix;
    static bool[,] visited;
    static int rows, cols;

    static int[] rowDirs = { -1, 1, 0, 0 };
    static int[] colDirs = { 0, 0, -1, 1 };

    static bool IsInBounds(int row, int col)
    {
        return row >= 0 && row < rows && col >= 0 && col < cols;
    }

    static void DFS(int row, int col, char letter)
    {
        visited[row, col] = true;

        for (int i = 0; i < 4; i++)
        {
            int newRow = row + rowDirs[i];
            int newCol = col + colDirs[i];

            if (IsInBounds(newRow, newCol) && !visited[newRow, newCol] && matrix[newRow, newCol] == letter)
            {
                DFS(newRow, newCol, letter);
            }
        }
    }

    static void Main()
    {
        rows = int.Parse(Console.ReadLine());
        cols = int.Parse(Console.ReadLine());

        matrix = new char[rows, cols];
        visited = new bool[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = line[j];
            }
        }
        int count = 0;
        SortedDictionary<char, int> areasCount = new SortedDictionary<char, int>();

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (!visited[row, col])
                {
                    char letter = matrix[row, col];

                    DFS(row, col, letter);

                    if (!areasCount.ContainsKey(letter))
                    {
                        areasCount[letter] = 0;
                    }
                    areasCount[letter]++;
                    count++;
                }
            }
        }

        Console.WriteLine($"Areas: {count}");
        foreach (var letter in areasCount.Keys)
        {
            Console.WriteLine($"Letter '{letter}' -> {areasCount[letter]}");
        }
    }
}
