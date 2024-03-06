namespace Fold_and_sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] originalArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int foldPoint = originalArray.Length / 4;
            int[] output = new int[foldPoint * 2];

            for (int i = 0; i < foldPoint; i++)
            {
                output[i] = originalArray[i + foldPoint] + originalArray[foldPoint - 1 - i];

                output[i + foldPoint] = originalArray[i + 2 * foldPoint] + originalArray[originalArray.Length - 1 - i];
            }

            Console.WriteLine(String.Join(' ', output));
        }
    }
}