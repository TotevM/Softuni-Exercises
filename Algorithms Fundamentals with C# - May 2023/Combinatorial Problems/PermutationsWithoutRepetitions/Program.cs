
namespace PermutationsWithoutRepetitions
{
    internal class Program
    {
        private static string[] arr;
        static void Main(string[] args)
        {
            arr = Console.ReadLine().Split().ToArray();
            Permute(0);

        }

        private static  void Permute(int index)
        {
            if (index>=arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr)) ;   
                return;
            }

            Permute(index+1);

            for (int i = index+1; i < arr.Length; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int index, int i)
        {
            (arr[index], arr[i]) = (arr[i], arr[index]);
        }
    }
}
