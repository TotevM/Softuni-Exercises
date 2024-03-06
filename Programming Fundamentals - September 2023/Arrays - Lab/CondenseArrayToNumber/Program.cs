namespace Condense_array_to_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int output = 0;
            int numbersLength = numbers.Length - 1;
            if (numbersLength == 0)
            {
                Console.WriteLine(numbers[0]);
                return;
            }
            for (int i = 0; i < numbersLength; i++)
            {
                int[] condensed = new int[numbers.Length - 1];
                for (int j = 0; j < condensed.Length; j++)
                    condensed[j] = numbers[j] + numbers[j + 1];
                numbers = condensed;
                output = condensed[0];
            }
            Console.WriteLine(output);
        }
    }
}