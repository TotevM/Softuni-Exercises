namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers= new Stack<int> ();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();

                switch (command[0])
                {
                    case 1:
                        numbers.Push(command[1]);
                        break;

                    case 2:
                        numbers.Pop();
                        break;

                    case 3:
                        if (numbers.Count != 0)
                        {
                            Console.WriteLine(numbers.Max());
                        }
                        else
                        { continue; }
                        break;

                    case 4:
                        if (numbers.Count != 0)
                        {
                            Console.WriteLine(numbers.Min());
                        }
                        else
                        { continue; }
                        
                        break;
                }
            }
            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
