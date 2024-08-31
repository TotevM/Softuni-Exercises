namespace FindAllPathsInALabyrinth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            char[,] arr= new char[rows, cols];
            int startRow=-1;
            int startCol=-1;
            bool hasFinish = false;

            for (int i = 0; i < rows; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                {
                    arr[i, j] = input[j];
                    if (arr[i, j]=='S')
                    {
                        startRow=i;
                        startCol=j;
                    }

                    if (arr[i, j]=='e')
                    {
                        hasFinish = true;
                    }
                }
            }

            if (startRow<0 || startCol<0)
            {
                Console.WriteLine("No starting point was found");
            }
            else if (!hasFinish)
            {
                Console.WriteLine("No final destination was found");
            }
            else
            {
                FindPaths(arr, startRow, startCol, new List<string>(), "");
            }
            
        }

        private static void FindPaths(char[,] arr, int row, int col, List<string> directions, string CurrentDirection)
        {
            if (row>=arr.GetLength(0) ||
                col >= arr.GetLength(1) ||
                row<0 || col<0 || arr[row, col] == 'v' ||
                arr[row, col] == '*')
            {
                return;
            }//Matrix borders and constraints

            directions.Add(CurrentDirection);
            
            if (arr[row,col]=='e')
            {
                Console.WriteLine(string.Join("", directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            
            }//Behavior when a solution is found

            arr[row, col] = 'v';//change the value to avoid returning in the same direction

            FindPaths(arr, row-1, col, directions, "U");
            FindPaths(arr, row+1, col, directions, "D");
            FindPaths(arr, row, col-1, directions, "L");
            FindPaths(arr, row, col+1, directions, "R");

            arr[row, col] = '-';//return the value when all possible paths are iterated
            directions.RemoveAt(directions.Count - 1);
        }
    }
}
