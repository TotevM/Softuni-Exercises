namespace ReverseArray
{
    public class Program
    {
        public static int[] arr;
        static void Main(string[] args)
        {
            arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Reverse(0);
            Console.WriteLine(string.Join(" ", arr));
        }

        private static void Reverse(int ind)
        {
            if (ind == arr.Length / 2)
            {
                return;
            }
            (arr[ind], arr[arr.Length - 1 - ind]) = (arr[arr.Length - 1 - ind], arr[ind]);
            Reverse(ind + 1);
        }
    }
}