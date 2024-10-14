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

        // Sort the array using quicksort
        QuickSort(array, 0, array.Length - 1);

        // Display the sorted array
        Console.WriteLine("Sorted array:");
        Console.WriteLine(string.Join(" ", array));
    }

    // Quicksort function
    static void QuickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            // Partition the array and get the pivot index
            int pivotIndex = Partition(array, low, high);

            // Recursively sort elements before and after the partition
            QuickSort(array, low, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, high);
        }
    }

    // Partition function
    static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high]; // Choose the last element as the pivot
        int i = low - 1; // Index of smaller element

        for (int j = low; j < high; j++)
        {
            // If the current element is smaller than or equal to the pivot
            if (array[j] <= pivot)
            {
                i++;

                // Swap array[i] and array[j]
                Swap(array, i, j);
            }
        }

        // Swap array[i+1] and the pivot (array[high])
        Swap(array, i + 1, high);

        return i + 1; // Return the index of the pivot
    }

    // Function to swap two elements in the array
    static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}
