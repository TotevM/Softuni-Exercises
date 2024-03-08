using System.Text;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            string word = Console.ReadLine();
            bool even = true;
            
            for (int i = 0; i < size[0] * size[1]; i++)
            {
                sb.Append(word);
            }
            Queue<char> chars = new Queue<char>(sb.ToString()
                .Substring(0, size[0] * size[1]));

            char[,] matrix = new char[size[0] , size[1]];

            for (int i = 0; i < size[0]; i++)
            {
                if (even == true)
                {
                    for (int k = 0; k < size[1]; k++)
                    {
                        matrix[i, k] = chars.Dequeue();
                    }
                    for (int k = 0; k < size[1]; k++)
                    {
                        Console.Write(matrix[i,k]);
                    }
                    Console.WriteLine();
                }
                else if(!even)
                {
                    for (int k = size[1]-1; k >= 0; k--)
                    {
                        matrix[i, k] = chars.Dequeue();
                    }
                    for (int k = 0; k < size[1]; k++)
                    {
                        Console.Write(matrix[i, k]);
                    }
                    Console.WriteLine();
                }
                even = !even;
            }
        }
    }
}
