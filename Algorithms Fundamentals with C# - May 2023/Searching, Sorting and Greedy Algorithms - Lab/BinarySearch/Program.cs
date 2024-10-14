using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        int[] sortedArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int target = int.Parse(Console.ReadLine());

        BinarySearch(sortedArray, target);
    }

    static void BinarySearch(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (array[mid] == target) 
            {
                Console.WriteLine(mid);
                return;
            }
            else if (array[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
    }
}
