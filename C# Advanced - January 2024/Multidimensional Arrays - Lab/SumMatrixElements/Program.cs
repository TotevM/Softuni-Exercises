namespace _1._Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input=Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int sum = 0;

            int[][] arr= new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] newArray = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                arr[i]= newArray;
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int k = 0; k < arr[i].Length; k++)
                {
                    sum+= arr[i][k];
                }
            }
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
