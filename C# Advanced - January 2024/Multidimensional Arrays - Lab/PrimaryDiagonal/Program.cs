namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int cols = n;
            int rows = n;
            int diagonalSum = 0;

            int[,] matrix=new int[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int k = 0; k < cols; k++)
                {
                    matrix[i,k]= input[k];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                diagonalSum += matrix[i, i];
            }
            Console.WriteLine(diagonalSum);
        }
    }
}
