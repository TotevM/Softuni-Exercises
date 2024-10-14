using System;

class Program
{
    static void Main()
    {
        // Prompt the user to enter the array size
        Console.Write("Enter the number of elements in the array: ");
        int size = int.Parse(Console.ReadLine());

        // Prompt the user to enter the elements of the array
        Console.WriteLine("Enter the array elements separated by spaces:");
        int[] array = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        if (array.Length != size)
        {
            Console.WriteLine("The number of elements does not match the specified size.");
            return;
        }

        // Sort the array using merge sort
        MergeSort(array, 0, array.Length - 1);

        // Display the sorted array
        Console.WriteLine("Sorted array:");
        Console.WriteLine(string.Join(" ", array));
    }

    // Merge Sort function
    static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            // Find the middle point
            int mid = left + (right - left) / 2;

            // Recursively sort the first half
            MergeSort(array, left, mid);

            // Recursively sort the second half
            MergeSort(array, mid + 1, right);

            // Merge the two halves
            Merge(array, left, mid, right);
        }
    }

    // Merge function to merge two sorted subarrays
    static void Merge(int[] array, int left, int mid, int right)
    {
        // Sizes of the two subarrays to be merged
        int n1 = mid - left + 1;
        int n2 = right - mid;

        // Temporary arrays
        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        // Copy data to temporary arrays leftArray[] and rightArray[]
        Array.Copy(array, left, leftArray, 0, n1);
        Array.Copy(array, mid + 1, rightArray, 0, n2);

        // Merge the temporary arrays

        // Initial indexes of the first and second subarrays
        int i = 0, j = 0;

        // Initial index of merged subarray array[]
        int k = left;
        while (i < n1 && j < n2)
        {
            if (leftArray[i] <= rightArray[j])
            {
                array[k] = leftArray[i];
                i++;
            }
            else
            {
                array[k] = rightArray[j];
                j++;
            }
            k++;
        }

        // Copy the remaining elements of leftArray[], if any
        while (i < n1)
        {
            array[k] = leftArray[i];
            i++;
            k++;
        }

        // Copy the remaining elements of rightArray[], if any
        while (j < n2)
        {
            array[k] = rightArray[j];
            j++;
            k++;
        }
    }
}
