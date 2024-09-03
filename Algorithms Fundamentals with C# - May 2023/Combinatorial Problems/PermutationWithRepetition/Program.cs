namespace PermutationWithRepetition
{
    internal class Program
    {
        private static string[] arr;
        static void Main(string[] args)
        {
            arr = Console.ReadLine().Split().ToArray();
            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            Permute(index + 1);

            var used = new HashSet<string> { arr[index] };

            for (int i = index + 1; i < arr.Length; i++)
            {
                if (!used.Contains(arr[i]))
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);

                    used.Add(arr[i]);
                }
            }
        }

        private static void Swap(int index, int i)
        {
            (arr[index], arr[i]) = (arr[i], arr[index]);
        }
    }


}
